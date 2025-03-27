using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    public GameObject ButtonPanel; 
    public int consumePoint1 = 10; 
    public int consumePoint2 = 10; 
    public int consumePoint3 = 10; 

    // Start is called before the first frame update
    void Start()
    {
        ButtonPanel.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.gameStatus == "PointsShortage" || GameController.gameStatus == "FinishSelected"){
            ButtonPanel.SetActive(false); 
        }

        if(GameController.gameStatus == "wait"){
            ButtonPanel.SetActive(true); 
        }
    }

    public void Selected1(){
        if(GameController.timePoint < consumePoint1){
            GameController.gameStatus = "PointsShortage"; 
        }

        if(GameController.timePoint >= consumePoint1){
            Debug.Log("Event Occure"); 
            GameController.gameStatus = "PointsShortage"; 
            GameController.timePoint = GameController.timePoint - consumePoint1; 
        }
    }

    public void Selected2(){
        if(GameController.timePoint < consumePoint2){
            GameController.gameStatus = "PointsShortage"; 
        }

        if(GameController.timePoint >= consumePoint2){
            Debug.Log("Event Occure"); 
            GameController.gameStatus = "PointsShortage"; 
            GameController.timePoint = GameController.timePoint - consumePoint2; 
        }
    }

    public void Selected3(){
        if(GameController.timePoint < consumePoint3){
            GameController.gameStatus = "PointsShortage"; 
        }

        if(GameController.timePoint >= consumePoint3){
            Debug.Log("Event Occure"); 
            GameController.gameStatus = "PointsShortage"; 
            GameController.timePoint = GameController.timePoint - consumePoint3; 
        }
    }
}
