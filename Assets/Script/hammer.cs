using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammer : MonoBehaviour
{ 

    //private Vector3 mouse;
    private Vector3 target;
    private bool isHit;

    private Animator animator;
    public SphereCollider bc;
    public Rigidbody rig;
    private bool jump;
    private bool Attack;
    void Start()
    {
        isHit = false;
        bc.enabled = true;
    }

    void Update()
    {
        // mouse = Input.mousePosition;
        //target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 10));
        //this.transform.position = target;
        if (Input.GetButtonDown("X") && isHit == false)
        {
            StartCoroutine("RodHit");
            bc.enabled = false;

        }

    }



    IEnumerator RodHit()
    {
        isHit = true;
        for (int i = 0; i < 10; i++)
        {
            
            bc.enabled = true;
           //animator.SetBool("Attack", true);

            yield return new WaitForSeconds(0.001f);
        }

        for (int j = 0; j < 30; j++)
        {
           
            bc.enabled = false;
           // animator.SetBool("Attack", false);
            yield return new WaitForSeconds(0.001f);
        }
        
    }
   
}



