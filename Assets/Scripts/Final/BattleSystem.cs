using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public enum BattleStatus
{
    wait,
    result,
    playerAttack,
    enemyAttack,
    playerDamage,
    enemyDamage,
    won,
    lost,
    special, 
}

public enum BattleHand
{
    attack,
    defence,
    speed,
}


public class BattleSystem : MonoBehaviour
{
    
    public BattleStatus battleStatus = BattleStatus.wait; 
    public TextMeshProUGUI mainMsg; 

    public Button attackButton; 
    public Button defenceButton; 
    public Button speedButton; 

    string msg1; 
    string msg2; 

    public float php = 500f; 
    public float ehp = 500f; 

    public GameObject playerHPSlider; 
    public GameObject enemyHPSlider; 

    float playerPower; 
    float enemyPower; 

    public float[] enemyStatus = new float[3]; 

    public GameObject cameraWait; 
    public GameObject cameraPlayer; 
    public GameObject cameraEnemy; 

    bool[] msg1Cameras = new bool[3]; 
    bool[] msg2Cameras = new bool[3]; 

    Animator playerAnimator; 
    Animator enemyAnimator; 

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤータグがついているオブジェクトのコンポーネントを取得する
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>(); 
        enemyAnimator = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>(); 

        BattleWait(); 

        for(int i = 0;i < enemyStatus.Length;i++){
            enemyStatus[i] = Random.Range(40,71); 
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SliderUpdate(){
        playerHPSlider.GetComponent<Slider>().value = php; 
        enemyHPSlider.GetComponent<Slider>().value = ehp; 
    }

    void BattleWait(){
        SliderUpdate(); 
        battleStatus = BattleStatus.wait; 
        cameraWait.SetActive(true); 
        playerAnimator.SetBool("attack1",false); 
        playerAnimator.SetBool("attack2",false); 
        playerAnimator.SetBool("damage",false); 
        enemyAnimator.SetBool("attack",false); 
        mainMsg.text = "Click to choose your move"; 
    }

    public void OnClickAttack(){
        playerPower = StatusController.attackPoint; 

        ButtonDesable(); 

        if(battleStatus != BattleStatus.wait){
            return; 
        }

        battleStatus = BattleStatus.result; 

        //敵の手がランダムに決まる
        BattleHand enemyHand = EnemyHandling(); 
        Debug.Log(enemyHand); 

        //勝敗の判定
        int result = Judge(BattleHand.attack,enemyHand); 

        ResultCol(result); 

        if(battleStatus != BattleStatus.result){
            StartCoroutine(BattleResult()); 
        }else{
            StartCoroutine(ShowBattle(msg1,msg2)); 
        }

        ButtonActive(); 
        attackButton.interactable = false; 
    }

    public void OnClickDefence(){
        playerPower = StatusController.defencePoint; 

        ButtonDesable(); 

        if(battleStatus != BattleStatus.wait){
            return; 
        }

        battleStatus = BattleStatus.result; 

        //敵の手がランダムに決まる
        BattleHand enemyHand = EnemyHandling(); 
        Debug.Log(enemyHand); 

        //勝敗の判定
        int result = Judge(BattleHand.defence,enemyHand); 

        ResultCol(result); 

        if(battleStatus != BattleStatus.result){
            StartCoroutine(BattleResult()); 
        }else{
            StartCoroutine(ShowBattle(msg1,msg2)); 
        }

        ButtonActive(); 
        defenceButton.interactable = false; 
    }

    public void OnClickSpeed(){
        playerPower = StatusController.speedPoint; 

        ButtonDesable(); 

        if(battleStatus != BattleStatus.wait){
            return; 
        }

        battleStatus = BattleStatus.result; 

        //敵の手がランダムに決まる
        BattleHand enemyHand = EnemyHandling(); 
        Debug.Log(enemyHand); 

        //勝敗の判定
        int result = Judge(BattleHand.speed,enemyHand); 

        ResultCol(result); 

        if(battleStatus != BattleStatus.result){
            StartCoroutine(BattleResult()); 
        }else{
            StartCoroutine(ShowBattle(msg1,msg2)); 
        }

        ButtonActive(); 
        speedButton.interactable = false; 
    }

    BattleHand EnemyHandling(){
        int rand = Random.Range(1,4); 
        if(rand == 1){
            enemyPower = enemyStatus[0]; 
        }else if(rand == 2){
            enemyPower = enemyStatus[1]; 
        }else if(rand == 3){
            enemyPower = enemyStatus[2]; 
        }
        return (BattleHand)rand; 
    }

    int Judge(BattleHand playerHand,BattleHand enemyHand){
        if(playerHand == enemyHand){
            return 0;   //引き分け
        }else if((playerHand == BattleHand.attack && enemyHand == BattleHand.defence) 
             || (playerHand == BattleHand.defence && enemyHand == BattleHand.speed) 
             || (playerHand == BattleHand.speed && enemyHand == BattleHand.attack)){
            if(Random.Range(0,2) == 0){
                playerAnimator.SetBool("attack1",true); 
            }else{
                playerAnimator.SetBool("attack2",true); 
            }
            
            return 1;   //勝ち
        }else{
            playerAnimator.SetBool("damage",true); 
            enemyAnimator.SetBool("attack",true); 

            return 2;   //負け
        }
    }

    IEnumerator ShowBattle(string msg1, string msg2){
        cameraWait.SetActive(msg1Cameras[0]); 
        cameraPlayer.SetActive(msg1Cameras[1]); 
        cameraEnemy.SetActive(msg1Cameras[2]); 

        mainMsg.text = msg1; 
        
        while(!Input.GetMouseButtonDown(0)){
            yield return null;   //何もしない
        }

        cameraWait.SetActive(msg2Cameras[0]); 
        cameraPlayer.SetActive(msg2Cameras[1]); 
        cameraEnemy.SetActive(msg2Cameras[2]); 

        mainMsg.text = msg2; 

        Debug.Log("msg2 shown"); 

        yield return new WaitForSeconds(0.3f); 

        while(!Input.GetMouseButtonDown(0)){
            yield return null;   //何もしない
        }

        Debug.Log("return wait"); 

        BattleWait();   //待ち状態に戻す
    }


    public void ButtonActive(){
        attackButton.interactable = true; 
        defenceButton.interactable = true; 
        speedButton.interactable = true; 
    }

    public void ButtonDesable(){
        attackButton.interactable = false; 
        defenceButton.interactable = false; 
        speedButton.interactable = false; 
    }

    void ResultCol(int result){
        switch(result){
            case 0: 
                float damage; 

                if(playerPower > enemyPower){
                    msg1Cameras[0] = false; 
                    msg1Cameras[1] = true; 
                    msg1Cameras[2] = false; 
                    msg2Cameras[0] = false; 
                    msg2Cameras[1] = false; 
                    msg2Cameras[2] = true; 

                    damage = playerPower - enemyPower; 
                    msg2 = "Your monster's ststistics were greater than your opponent. You damaged " + damage + " HP to your opponent. "; 
                    ehp -= damage; 

                    if(ehp <= 0){
                        battleStatus = BattleStatus.won; 
                    }

                }else if(playerPower < enemyPower){
                    msg1Cameras[0] = false; 
                    msg1Cameras[1] = false; 
                    msg1Cameras[2] = true; 
                    msg2Cameras[0] = false; 
                    msg2Cameras[1] = true; 
                    msg2Cameras[2] = false; 

                    damage = enemyPower - playerPower; 
                    msg2 = "Your monster's ststistics were less than your opponent. They damaged " + damage + " HP to your monster. "; 
                    php -= damage; 

                    if(php <= 0){
                        battleStatus = BattleStatus.lost; 
                    }

                }else{
                    msg1Cameras[0] = true; 
                    msg1Cameras[1] = false; 
                    msg1Cameras[2] = false; 
                    msg2Cameras[0] = true; 
                    msg2Cameras[1] = false; 
                    msg2Cameras[2] = false; 

                    msg2 = "Your monster's statistics were the same as the opponent. Nothing happened. "; 
                }
                msg1 = "The actions were the same. "; 

                break; 
            
            case 1: 
                msg1Cameras[0] = false; 
                msg1Cameras[1] = true; 
                msg1Cameras[2] = false; 
                msg2Cameras[0] = false; 
                msg2Cameras[1] = false; 
                msg2Cameras[2] = true; 

                damage = 2 * playerPower - enemyPower; 
                if(damage < 0) damage = 0; 

                msg1 = "Your monster's action sucseeded! "; 
                msg2 = "The enemy has taken " + damage + " damage. "; 

                ehp -= damage; 

                if(ehp <= 0){
                        battleStatus = BattleStatus.won; 
                }

                break; 

            case 2: 
                msg1Cameras[0] = false; 
                msg1Cameras[1] = false; 
                msg1Cameras[2] = true; 
                msg2Cameras[0] = false; 
                msg2Cameras[1] = true; 
                msg2Cameras[2] = false; 

                damage = 1.5f * enemyPower - playerPower; 
                if(damage < 0) damage = 0; 

                msg1 = "The enemy's action sucseeded... "; 
                msg2 = "Your monster has taken " + damage + " damage. "; 

                php -= damage; 

                if(php <= 0){
                    battleStatus = BattleStatus.lost; 
                }

                break; 
        }
    }

    IEnumerator BattleResult(){
        if(battleStatus == BattleStatus.won){
            mainMsg.text = "Your player has won the battle!"; 
        }else{
            mainMsg.text = "The opponet has won the battle..."; 
        }

        while(!Input.GetMouseButtonDown(0)){
            yield return null; 
        }

        SceneManager.LoadScene("End"); 
    }
}
