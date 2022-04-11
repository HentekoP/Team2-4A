using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    public ParticleSystem exp;
    public GameObject obj;
    public bool ExprosionFlg = false;

    public float BombPower = 100f;
    public float BombRadius = 30f;
    void Update()
    {
        Vector3 explosionPos = transform.position;
        Rigidbody rb = GetComponent<Rigidbody>();

        float tri = Input.GetAxis("RT");

        if (tri == 1.0f)
        {
            rb.AddExplosionForce(BombPower, explosionPos, BombRadius, 0f,ForceMode.Impulse);
            ExprosionFlg = true;
            Debug.Log("R trigger:" + tri);

            
        }

        if (ExprosionFlg == true)
        {
            Exprosion();
            ExprosionFlg = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Hammer")
        {
            Exprosion();
        }
    }

    void Exprosion()
    {
        exp.transform.position = obj.transform.position;
        exp.Play();
        //Destroy(obj);
        obj.SetActive(false);
    }
}
