using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

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

    string msg1; 
    string msg2; 

    // Start is called before the first frame update
    void Start()
    {
        BattleWait(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BattleWait()
    {
        battleStatus = BattleStatus.wait; 
        mainMsg.text = "Click to choose your move"; 
    }

    public void OnClickAttack(){
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

    IEnumerator ShowBattle(msg1, string msg2){
        mainMsg.text = msg1; 
        
        while(!Input.GetMouseButtonDown(0)){
            yield return null;   //何もしない
        }

        mainMsg.text = msg2; 

        while(!Input.GetMouseButtonDown(0)){
            yield return null;   //何もしない
        }

        BattleWait();   //待ち状態に戻す
    }
}
