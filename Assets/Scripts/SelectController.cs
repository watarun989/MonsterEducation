using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    public GameObject buttonPanel;
    public int consumePoint01 = 10;
    public int consumePoint02 = 10;
    public int consumePoint03 = 10;

    // Start is called before the first frame update
    void Start()
    {
        buttonPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameStatus == "PointsShortage" || GameController.gameStatus == "FinishSelected")
        {
            buttonPanel.SetActive(false);
        }

        if (GameController.gameStatus == "wait")
        {
            buttonPanel.SetActive(true);
        }
    }

    public void Selected01()
    {
        //timePointが選択肢1の消費ポイントより小さい場合
        if (GameController.timePoint < consumePoint01)
        {
            GameController.gameStatus = "PointsShortage";
        }
        else
        {
            Debug.Log("Event Occure");
            GameController.timePoint -= consumePoint01;
        }
    }

    public void Selected02()
    {
        if (GameController.timePoint < consumePoint02)
        {
            GameController.gameStatus = "PointsShortage";
        }
        else
        {
            Debug.Log("Event Occure");
            GameController.timePoint -= consumePoint02;
        }
    }

    public void Selected03()
    {
        if (GameController.timePoint < consumePoint03)
        {
            GameController.gameStatus = "PointsShortage";
        }
        else
        {
            Debug.Log("Event Occure");
            GameController.timePoint -= consumePoint03;
        }
    }
}
