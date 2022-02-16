using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammer : MonoBehaviour

{

    void OnCollisionEnter(Collision collision)
    {
       
        var rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;

        Debug.Log("Hit");
        
    }

}