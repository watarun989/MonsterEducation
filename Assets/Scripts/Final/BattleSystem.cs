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
        //Judge(BattleHand.attack,enemyHand); 

    }

    BattleHand EnemyHandling(){
        return (BattleHand)Random.Range(1,4); 
    }
}
