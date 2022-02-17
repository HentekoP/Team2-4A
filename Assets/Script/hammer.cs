using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammer : MonoBehaviour

{
    public Rigidbody rig;
    void OnCollisionEnter(Collision collision)
    {


        rig = collision.gameObject.GetComponent<Rigidbody>();
        rig.isKinematic = false;
        Debug.Log("Hit");
       
        
    }

}