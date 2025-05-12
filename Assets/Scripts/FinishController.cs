using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class FinishController : MonoBehaviour
{
    public GameObject finishPanel; 
    public GameObject confirmPanel; 

    // Start is called before the first frame update
    void Start()
    {
        confirmPanel.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onFinish(){
        GameController.gameStatus = "FinishSelected"; 
        confirmPanel.SetActive(true); 
        finishPanel.SetActive(false); 
    }

    public void onFinishYes(){
        Debug.Log("Finished"); 
        StartCoroutine(onFinishYesCoroutine()); 
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
