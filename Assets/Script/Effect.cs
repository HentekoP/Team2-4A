using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    //    public ParticleSystem efe;
    public GameObject particleObject;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            Playeffect(collision);
        }
    }

    void Playeffect(Collision collision)
    {
        Instantiate(particleObject, this.transform.position, Quaternion.identity);
        particleObject.transform.position = collision.contacts[0].point;
        //particleObject.Play();
    }
}
