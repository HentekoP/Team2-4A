using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammer : MonoBehaviour


{
    public SphereCollider bc;
    public Rigidbody rig;



    void Update()
    {
        if (Input.GetKeyDown("joystick button 2"))
        {
            Debug.Log("button2");
            bc.enabled = true;
        }
        else
        {
            bc.enabled = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {


        rig = collision.gameObject.GetComponent<Rigidbody>();
        rig.isKinematic = false;
        

        Debug.Log("Hit");


    }


}