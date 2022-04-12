using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float BombPower = 100f;
    public float BombRadius = 30f;
    GameObject Bomb;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Bomb = GameObject.Find("Old-timerbombprefab");
        Vector3 explosionPos = Bomb.transform.position;

        Collider[] hitColliders = Physics.OverlapSphere(explosionPos, BombRadius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            var rb = hitColliders[i].GetComponent<Rigidbody>();
            if (Input.GetAxis("RT") == 1.0f)
            {
                if (rb)
                {
                    rb.AddExplosionForce(BombPower, explosionPos, BombRadius, 1f, ForceMode.Impulse);
                }
            }
        }
    }
}
