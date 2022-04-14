using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    public ParticleSystem exp;
    public GameObject obj;
    public bool ExprosionFlg = false;

    GameObject Bomb;

    RaycastHit hit;

    void Start()
    {
        Bomb = GameObject.Find("prefaberbombprefab(Clone)");
    }

    void Update()
    {
        float tri = Input.GetAxis("RT");

        Ray ray = new Ray(obj.transform.position, transform.TransformDirection(Vector3.up));

            if (tri == 1.0f)
            {
                ExprosionFlg = true;
                Debug.Log("R trigger:" + tri);

                if (Physics.SphereCast(ray, 1f, out hit, 50f))
                {
                    Debug.Log(hit.collider.gameObject.name);
                }

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
