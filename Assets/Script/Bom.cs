using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    public ParticleSystem exp;
    public GameObject obj;
    public bool ExprosionFlg = false;

    void Update()
    {
        if (/* && */Input.GetButtonDown("joystick button 12"))
        {
            ExprosionFlg = true;
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
        exp.Play();
        Destroy(obj);
    }
    //void Update()
    //{
    //    if (Input.GetButton("R2"))
    //        Debug.Log("thisone");
    //}
}
