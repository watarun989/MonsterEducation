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

    // Start is called before the first frame update
    void Start()
    {
        BattleWait(); 

        for(int i = 0;i < enemyStatus.Length;i++){
            enemyStatus[i] = Random.Range(100,151); 
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

    void BattleWait()
    {
        SliderUpdate(); 
        battleStatus = BattleStatus.wait; 
        mainMsg.text = "Click to choose your move"; 
        ButtonActive(); 
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
            return 1;   //勝ち
        }else{
            return 2;   //負け
        }
    }

    IEnumerator ShowBattle(string msg1, string msg2){
        mainMsg.text = msg1; 
        
        while(!Input.GetMouseButtonDown(0)){
            yield return null;   //何もしない
        }

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
                    damage = playerPower - enemyPower; 
                    msg2 = "Your monster's ststistics were greater than your opponent. You damaged " + damage + " HP to your opponent. "; 
                    ehp -= damage; 

                    if(ehp <= 0){
                        battleStatus = BattleStatus.won; 
                    }

                }else if(playerPower < enemyPower){
                    damage = enemyPower - playerPower; 
                    msg2 = "Your monster's ststistics were less than your opponent. They damaged " + damage + " HP to your monster. "; 
                    php -= damage; 

                    if(php <= 0){
                        battleStatus = BattleStatus.lost; 
                    }

                }else{
                    msg2 = "Your monster's statistics were the same as the opponent. Nothing happened. "; 
                }
                msg1 = "The actions were the same. "; 
                break; 
            
            case 1: 
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
