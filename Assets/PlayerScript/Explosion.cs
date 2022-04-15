using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float BombPower = 0.01f;
    public float BombRadius = 15f;
    GameObject Bomb;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Bomb = GameObject.Find("Old-timerbombprefab(Clone)");
        Vector3 explosionPos =transform.position;

        Collider[] hitColliders = Physics.OverlapSphere(explosionPos, BombRadius);
        foreach(Collider hit in hitColliders)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                if (Input.GetAxis("RT") == 1.0f)
                {
                    rb.AddExplosionForce(BombPower, explosionPos, BombRadius, 3f, ForceMode.Impulse);
                }
            }
        }
    }
}
