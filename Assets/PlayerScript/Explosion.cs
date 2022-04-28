using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Rigidbody rb;
    static float counter;
    bool countflg;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        counter = 0;
        countflg = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnParticleCollision(GameObject other)
    {
        rb.isKinematic = false;
        rb.GetComponent<DestroyedPieceController>().cause_damage(Random.onUnitSphere);
        rb.AddForce(Random.onUnitSphere * 15000f);
        
    }
    public static float ObjectCount()
    {
        return counter;
    }
}
