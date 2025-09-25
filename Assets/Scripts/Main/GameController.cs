using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static public string gameStatus; 
    static public int timePoint = 30; 

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = "wait"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
