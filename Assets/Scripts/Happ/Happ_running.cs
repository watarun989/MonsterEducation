using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

//SleepScene Run Script
public class Happ_running : MonoBehaviour
{
    float dir; 
    public float speed = 3.0f; 
    public Camera cameraA; //Sleep Camera
    public Camera cameraB; //Main Camera
    public Camera cameraC; //Run Camera
    public GameObject buttonPanel; 
    public int[,] statusPatterns = new int[,]{
        {1,0,2},{1,0,-1},{-2,0,0}
    }; 
    public TextMeshProUGUI runText; 

    // Start is called before the first frame update
    void Start()
    {
        dir = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        dir = Mathf.Sin(Time.time * 2); 

        if(dir > 0){
            transform.rotation = Quaternion.Euler(0,90,0); 
        }else if(dir < 0){
            transform.rotation = Quaternion.Euler(0,270,0); 
        }

        transform.position += transform.forward * speed * Time.deltaTime; 
    }

    public void runSelected(){
        cameraC.enabled = true; 
        cameraA.enabled = false; 
        cameraB.enabled = false; 
        buttonPanel.SetActive(false); 
        int rand = Random.Range(0,3); 
        StatusController.attackPoint += statusPatterns[rand,0]; 
        StatusController.defencePoint += statusPatterns[rand,1]; 
        StatusController.speedPoint += statusPatterns[rand,2]; 
        runText.text = "Your monster's attack power has changed by " + statusPatterns[rand,0] + " Point(s)! \n"; 
        runText.text += "It's defence has changed by " + statusPatterns[rand,1] + " Point(s) too! \n"; 
        runText.text += "Lastly, it's speed has changed by " + statusPatterns[rand,2] + " Point(s)! \n"; 
        runText.text += "Click to go back. "; 
        StartCoroutine(WaitForClick()); 
    }

    IEnumerator WaitForClick(){
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0)); 
        FinishController.days ++; 
        GameController.timePoint = 100; 
        SceneManager.LoadScene("Main"); 
    }
}
