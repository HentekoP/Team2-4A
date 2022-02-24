using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammer : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    //private Vector3 mouse;
    private Vector3 target;
    private bool isHit;

    public MeshCollider bc;
    public Rigidbody rig;
    public float m_Thrust = 20f;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
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
            
            bc.enabled = true;
            yield return new WaitForSeconds(0.001f);
        }

        for (int j = 0; j < 30; j++)
        {
           
            bc.enabled = false;

            yield return new WaitForSeconds(0.001f);
        }
        isHit = false;
    }
    void OnCollisionEnter(Collision collision)
    {


        rig = collision.gameObject.GetComponent<Rigidbody>();
        rig.isKinematic = false;
        m_Rigidbody.AddForce(transform.up * m_Thrust);

        Debug.Log("Hit");


    }
}



