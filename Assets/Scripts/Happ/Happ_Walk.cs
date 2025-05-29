using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Happ_Walk : MonoBehaviour
{
    public float speed = 2; 
    public bool runStart; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!runStart){
            return; 
        }
        Rigidbody rb = GetComponent<Rigidbody>(); 
        rb.velocity = new Vector3(0,rb.velocity.y,-speed * Time.deltaTime * 10); 
    }
}
