using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("ばくはーつ");
       // rb.isKinematic = false;
        rb.GetComponent<DestroyedPieceController>().cause_damage(Random.onUnitSphere * 45);
        rb.AddForce(Random.onUnitSphere * 95000f);
    }
}
