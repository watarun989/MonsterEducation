using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI mainText; 
    public TalkDatas mainMessage; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.gameStatus == "wait"){
            mainText.text = mainMessage.datas[0].text; 
        }

        if(GameController.gameStatus == "PointsShortage"){
            mainText.text = mainMessage.datas[1].text;

            //マウスの左クリックかリターンがおされたら
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)){
                GameController.gameStatus = "wait"; 
            }
        }

        if(GameController.gameStatus == "FinishSelected"){
            //終了するかどうかのモードにあわせた処理
        }
    }
}
