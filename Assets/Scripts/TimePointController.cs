using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class TimePointController : MonoBehaviour
{
    int currentTimePoint; 
    public TextMeshProUGUI timePoint; 

    // Start is called before the first frame update
    void Start()
    {
        timePoint.text = currentTimePoint.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        timePoint.text = GameController.timePoint.ToString(); 
    }
}
