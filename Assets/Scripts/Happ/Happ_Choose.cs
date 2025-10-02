using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class Happ_Choose : MonoBehaviour
{
    string[] chooseMsg = {"Oh no! Your monster jumped into a puddle!","Good choice. Let's go home."}; 
    public TextMeshProUGUI chooseText; 

    public Camera mainCamera; 
    public Camera correctCamera; 
    public Camera wrongCamera; 

    public GameObject buttonPanel; 

    int result; 

    public int[,] statusPatterns = new int[,]{
        {-6,-5,-3},{8,7,9}
    }; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Chose(){
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

        StartCoroutine(WalkStart()); 
    }

    IEnumerator WalkStart(){
        Happ_Walk.runStart = true; 
        yield return new WaitForSeconds(3); 
        chooseText.text = chooseMsg[result]; 

        chooseText.text = "Your monster's attack power has changed by " + statusPatterns[result,0] + " Point(s)! \n"; 
        chooseText.text += "It's defence has changed by " + statusPatterns[result,1] + " Point(s) too! \n"; 
        chooseText.text += "Lastly, it's speed has changed by " + statusPatterns[result,2] + " Point(s)! \n"; 
        chooseText.text += "Click to go back. "; 

        StartCoroutine(WaitClick()); 
    }

    IEnumerator WaitClick(){
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0)); 
        FinishController.days++; 
        GameController.timePoint = 30; 

        if(FinishController.days == 4){
            SceneManager.LoadScene("Final"); 
        }else{
            SceneManager.LoadScene("Main"); 
        }
    }
}
