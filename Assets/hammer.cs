using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammer : MonoBehaviour

{
    
      void OnTriggerEnter(Collider other)
    {
        
                gameObject.GetComponent<Rigidbody>();

                
                gameObject.isKinematic = false;
               
                
            }
        }