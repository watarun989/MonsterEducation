using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class PlayerStatus : MonoBehaviour
{
    public TextMeshProUGUI atkText; 
    public TextMeshProUGUI defText; 
    public TextMeshProUGUI spdText; 

    // Start is called before the first frame update
    void Start()
    {
        atkText.text = StatusController.attackPoint.ToString(); 
        defText.text = StatusController.defencePoint.ToString(); 
        spdText.text = StatusController.speedPoint.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
