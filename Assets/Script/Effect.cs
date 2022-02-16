using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public ParticleSystem efe;

    void OnCollisionEnter(Collision collision)
    {
        Playeffect(collision);
    }

    void Playeffect(Collision collision)
    {
        efe.transform.position = collision.contacts[0].point;
        efe.Play();
    }
}
