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

        if (gameObject.CompareTag("iskinematicoff"))
        {
            rig = collision.gameObject.GetComponent<Rigidbody>();
            if (rig)
            {
                //  Invoke("hazureru", 1);
            }
            else

                //  rig.isKinematic = true;



                Debug.Log("Hit");


        }

        void OnCollisionExit(Collision collision2 )
        {
            if (collision.gameObject.tag == "iskinematicoff")
            {
                Invoke("hazureru", 1);

            }


        }

        void hazureru()
        {
            rig.isKinematic = false;
        }
    }
}



