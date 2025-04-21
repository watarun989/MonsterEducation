using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : MonoBehaviour
{
    public Transform center; 
    public float radius = 3.0f; 
    public float speed = 1.0f; 
    float angle = 0; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle += speed * Time.deltaTime; 
        float x = Mathf.Cos(angle) * radius; 
        float z = Mathf.Sin(angle) * radius; 
        Vector3 newPosition = center.position + new Vector3 (x,0,z); 
        transform.position = newPosition; 
    }
}
