using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class Happ_sleep : MonoBehaviour
{
    public GameObject cameraA; //Sleep Camera
    public GameObject cameraB; //Main Camera
    public GameObject cameraC; //Run Camera
    public GameObject zzz; 
    public GameObject buttonPanel; 
    public int[,] statusPatterns = new int[,]{
        {7,15,5},{6,-10,7},{-4,-8,-5}
    }; 
    public TextMeshProUGUI sleepText; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sleepSelected(){
        cameraA.GetComponent<Camera>().enabled = true; 
        cameraB.GetComponent<Camera>().enabled = false; 
        cameraC.GetComponent<Camera>().enabled = false; 
        zzz.SetActive(true); 
        buttonPanel.SetActive(false); 
        int rand = Random.Range(0,3); 
        StatusController.attackPoint += statusPatterns[rand,0]; 
        StatusController.defencePoint += statusPatterns[rand,1]; 
        StatusController.speedPoint += statusPatterns[rand,2]; 
        sleepText.text = "Your monster's attack power has changed by " + statusPatterns[rand,0] + " Point(s)! \n"; 
        sleepText.text += "It's defence has changed by " + statusPatterns[rand,1] + " Point(s) too! \n"; 
        sleepText.text += "Lastly, it's speed has changed by " + statusPatterns[rand,2] + " Point(s)! \n"; 
        sleepText.text += "Click to go back. "; 
        StartCoroutine(WaitForClick()); 
    }

    IEnumerator WaitForClick(){
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0)); 
        FinishController.days ++; 
        GameController.timePoint = 30; 
        
        if(FinishController.days == 4){
            SceneManager.LoadScene("Final"); 
        }else{
            SceneManager.LoadScene("Main"); 
        }
    }
}
