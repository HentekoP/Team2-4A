using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    public ParticleSystem exp;
    public GameObject obj;
    static bool ExprosionFlg = false;

    void Start()
    {
    }

    void Update()
    {
        float tri = Input.GetAxis("RT");

        if (tri == 1.0f && GameObject.FindWithTag("Switch") == true)
        {
            ExprosionFlg = true;
            reticleColor.BombIns = false;
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
        Instantiate(exp, this.transform.localPosition, Quaternion.identity);
        Destroy(obj);
    }
    public static bool ExpFlg()
    {
        return ExprosionFlg;
    }
}
