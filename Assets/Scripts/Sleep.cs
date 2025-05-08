using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    public Camera cameraA; //Sleep Camera
    public Camera cameraB; //Main Camera
    public GameObject zzz; 
    public GameObject buttonPanel; 
    public int[,] statusPatterns = new int[,]{
        {1,2,0},{0,1,-1},{0,-2,0}
    }; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sleepSelected(){
        cameraA.enabled = true; 
        cameraB.enabled = false; 
        zzz.SetActive(true); 
        buttonPanel.SetActive(false); 
        int rand = Random.Range(0,3); 
    }
}
