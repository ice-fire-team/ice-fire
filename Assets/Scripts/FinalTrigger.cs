using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FinalTrigger : MonoBehaviour
{
    public bool hasPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)  
    {
        if(col.gameObject.tag == "Player")
        {
            hasPlayer = true;
        }
    }
    
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            hasPlayer = false;
        } 
    }
    

}
