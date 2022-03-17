using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshrig : MonoBehaviour
{
    //private Vector3 mouse;
    private Vector3 target;
    private bool isHit;


    public SphereCollider bc;
    public Rigidbody rig;


  
    void Start()
    {
        //isHit = true;
        //rig.isKinematic = true;

    }

     void FixedUpdate()
    {
        //rig.isKinematic = true;
    }

    

    void OnCollisionEnter(Collision collision)
    {


        rig = collision.gameObject.GetComponent<Rigidbody>();
        if (rig)
        {
           // rig.isKinematic = false;
        }
        else
        
             //  rig.isKinematic = true;
       
            
        
        Debug.Log("Hit");


    }

    private void OnCollisionExit(Collision collision)
    {
        rig.isKinematic = false;
    }
}



