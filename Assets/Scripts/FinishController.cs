using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro; 

public class FinishController : MonoBehaviour
{
    public GameObject finishPanel; 
    public GameObject confirmPanel; 
    public TextMeshProUGUI daysText; 
    static public int days = 1; 

    // Start is called before the first frame update
    void Start()
    {
        daysText.text = "1"; 
        confirmPanel.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        daysText.text = days.ToString(); 
    }

    public void onFinish(){
        GameController.gameStatus = "FinishSelected"; 
        confirmPanel.SetActive(true); 
        finishPanel.SetActive(false); 
    }

    public void onFinishYes(){
        Debug.Log("Finished"); 
        StartCoroutine(onFinishYesCoroutine()); 

        // if(daysText == "1"){
        //     daysText.text = "2"
        // }else 
        // if(daysText == "2"){
        //     daysText.text = "3"
        // }else 
        // if(daysText == "3"){
        //     daysText.text = "4"
        // }else
        // if(daysText == "4"){
        //     daysText.text = "5"
        // }else
        // if(daysText == "5"){
        //     daysText.text = "6"
        // }else
        // if(daysText == "6"){
        //     daysText.text = "7"
        // }
    }

    public void onFinishNo(){
        finishPanel.SetActive(true); 
        confirmPanel.SetActive(false); 
        GameController.gameStatus = "wait"; 
    }

    public void ReloadScene(){
        GameController.timePoint = 100; 
        SceneManager.LoadScene("Main"); 
    }

    IEnumerator onFinishYesCoroutine(){
        yield return new WaitForSeconds(2.0f); 
        SceneManager.LoadScene("Sleep"); 
    }
}
