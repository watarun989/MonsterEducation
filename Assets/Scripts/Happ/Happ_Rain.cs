using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class Happ_Rain : MonoBehaviour
{
    string[] chooseMsg = {"Oh no! Its Raining and your monster is all wet! ","Good choice. Let's go home."}; 
    public TextMeshProUGUI chooseText; 

    public Camera mainCamera; 
    public Camera correctCamera; 
    public Camera wrongCamera; 

    public GameObject buttonPanel; 

    int result; 

    public int[,] statusPatterns = new int[,]{
        {0,-2,-1},{0,2,1}
    }; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChoseRain(){
        buttonPanel.SetActive(false); 

        result = Random.Range(0,2); 

        StatusController.attackPoint += statusPatterns[result,0]; 
        StatusController.defencePoint += statusPatterns[result,1]; 
        StatusController.speedPoint += statusPatterns[result,2]; 

        mainCamera.enabled = false; 

        if(result == 0){
            correctCamera.enabled = false; 
            wrongCamera.enabled = true; 
        }else{
            wrongCamera.enabled = false; 
            correctCamera.enabled = true; 
        }

        StartCoroutine(RainWalkStart()); 
    }

    IEnumerator RainWalkStart(){
        Happ_Walk.runStart = true; 
        yield return new WaitForSeconds(3); 
        chooseText.text = chooseMsg[result]; 

        chooseText.text = "Your monster's attack power has changed by " + statusPatterns[result,0] + " Point(s)! \n"; 
        chooseText.text += "It's defence has changed by " + statusPatterns[result,1] + " Point(s) too! \n"; 
        chooseText.text += "Lastly, it's speed has changed by " + statusPatterns[result,2] + " Point(s)! \n"; 
        chooseText.text += "Click to go back. "; 

        StartCoroutine(RainWaitClick()); 
    }

    IEnumerator RainWaitClick(){
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0)); 
        FinishController.days++; 
        GameController.timePoint = 100; 
        SceneManager.LoadScene("Main"); 
    }
}
