using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class StatusController : MonoBehaviour
{
    static public int attackPoint = 30; 
    static public int defencePoint = 30; 
    static public int speedPoint = 30; 
    public TextMeshProUGUI attackText; 
    public TextMeshProUGUI defenceText; 
    public TextMeshProUGUI speedText; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackText.text = attackPoint.ToString(); 
        defenceText.text = defencePoint.ToString(); 
        speedText.text = speedPoint.ToString(); 
    }
}
