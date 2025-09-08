using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI; 

public enum BattleStatus
{
    wait,
    result,
    playerAttack,
    enemyAttack,
    playerDamage,
    enemyDamage,
    win,
    lose,
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

    public float php = 100f; 
    public float ehp = 100f; 

    public GameObject playerHPSlider; 
    public GameObject enemyHPSlider; 

    // Start is called before the first frame update
    void Start()
    {
        BattleWait(); 

        playerHPSlider.GetComponent<Slider>().value = php/100; 
        enemyHPSlider.GetComponent<Slider>().value = ehp/100; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BattleWait()
    {
        battleStatus = BattleStatus.wait; 
        mainMsg.text = "Click to choose your move"; 
        ButtonActive(); 
    }

    public void OnClickAttack(){

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

        switch(result){
            case 0: 
                msg1 = "The actions were the same. "; 
                msg2 = "The monster with the most statistics won. "; 
                break; 
            
            case 1: 
                msg1 = "Your monster's action sucseeded! "; 
                msg2 = "The enemy has taken damage. "; 
                break; 

            case 2: 
                msg1 = "The enemy's action sucseeded... "; 
                msg2 = "Your monster has taken damage. "; 
                break; 
        }

        StartCoroutine(ShowBattle(msg1,msg2)); 
    }

    public void OnClickDefence(){

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

        switch(result){
            case 0: 
                msg1 = "The actions were the same. "; 
                msg2 = "The monster with the most statistics won. "; 
                break; 
            
            case 1: 
                msg1 = "Your monster's action sucseeded! "; 
                msg2 = "The enemy has taken damage. "; 
                break; 

            case 2: 
                msg1 = "The enemy's action sucseeded... "; 
                msg2 = "Your monster has taken damage. "; 
                break; 
        }

         StartCoroutine(ShowBattle(msg1,msg2)); 
    }

    public void OnClickSpeed(){

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

        switch(result){
            case 0: 
                msg1 = "The actions were the same. "; 
                msg2 = "The monster with the most statistics won. "; 
                break; 
            
            case 1: 
                msg1 = "Your monster's action sucseeded! "; 
                msg2 = "The enemy has taken damage. "; 
                break; 

            case 2: 
                msg1 = "The enemy's action sucseeded... "; 
                msg2 = "Your monster has taken damage. "; 
                break; 
        }

        StartCoroutine(ShowBattle(msg1,msg2)); 
    }

    BattleHand EnemyHandling(){
        return (BattleHand)Random.Range(1,4); 
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
}
