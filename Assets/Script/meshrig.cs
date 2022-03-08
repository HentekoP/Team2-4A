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
        isHit = true;

    }


    void OnCollisionEnter(Collision collision)
    {


        rig = collision.gameObject.GetComponent<Rigidbody>();
        //if ()
        //{
        //         rig.isKinematic = false;
        //}

        rig.isKinematic = false;

        Debug.Log("Hit");


    }
}

