﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamaa2 : MonoBehaviour
{
    //private Vector3 mouse;
    private Vector3 target;
    private bool isHit;

 
 
    public Rigidbody rig;

    void Start()
    {
        isHit = false;
    }

    void Update()
    {
        // mouse = Input.mousePosition;
        //target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 10));
        //this.transform.position = target;
        if (Input.GetButtonDown("x") && isHit == false)
        {
            StartCoroutine("RodHit");
        }

    }

    

    IEnumerator RodHit()
    {
        isHit = true;
        for (int i = 0; i < 10; i++)
        {
            transform.Rotate(0, 0, 9);
        
            yield return new WaitForSeconds(0.0000000000000000000000000000000000001f);
        }

        for (int j = 0; j < 30; j++)
        {
            transform.Rotate(0, 0, -3);
           
            
            yield return new WaitForSeconds(0.000000000000000000000000000000000001f);
        }
        isHit = false;
    }
    
}



   