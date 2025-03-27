using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class TimePointController : MonoBehaviour
{
    int currentTimePoint; 
    public TextMeshProUGUI timePoint; 

    // Start is called before the first frame update
    void Start()
    {
        timePoint.text = currentTimePoint.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        //選択肢によって消費され変化するGameControllerのtimePointが、把握していた数値(current)と異なっていることに気づいたら、値を更新してパネルに再表示
        if(GameController.timePoint != currentTimePoint)
        {
            currentTimePoint = GameController.timePoint;
            timePoint.text = currentTimePoint.ToString();
        }
    }
}
