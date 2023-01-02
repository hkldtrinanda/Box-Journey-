using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public GameObject gate, interactInfo;
    

    public Animator animGate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactInfo.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animGate.SetBool("Open", true);
                /*Destroy(gate, 2f);*/
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            interactInfo.SetActive(true);

        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            interactInfo.SetActive(false);
            
        }
    }
}
