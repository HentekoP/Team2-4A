using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reticleColor : MonoBehaviour
{
    [SerializeField]
    private Image aimPointImage;

    private Vector3 pos;

    [SerializeField]
    private GameObject bombPrefab;
    float Raycastlength = 0;
    float ColorTP;
    int bombcount = 5;
    bool pushcount = false;
    GameObject cd;
    GameObject cd2;
    // Start is called before the first frame update
    void Start()
    {
        cd = transform.GetChild(0).gameObject;
        cd2 = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (cd.activeSelf == true)
        {
            Raycastlength = 1.4f;
        }
        else if (cd2.activeSelf == true)
        {
            Raycastlength = 2.5f;
        }
        else
        {
            ColorTP = 0f;
        }
        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);


        if (Physics.Raycast(ray, out hit, Raycastlength))
        {
            string hitTag = hit.collider.tag;

            pos = hit.normal / 3 + hit.collider.transform.position;

            if (pushcount == false)
            {
                if (Input.GetButton("x") && bombcount > 0)
                {
                    pushcount = true;
                    Instantiate(bombPrefab, pos,Quaternion.Euler(0,transform.rotation.y,0));
                    bombcount -=1;
                }
            }
            else
            {
                pushcount = false;
            }
            if (bombcount <= 0)
            {
                cd2.SetActive(false);
            }
            if ((hitTag.Equals("Block")))
            {
                ColorTP = 1.0f;
            }
            else
            {
                ColorTP = 0.2f;
            }
        }
        else
        {
            ColorTP = 0.2f;
        }
        aimPointImage.color = new Color(1.0f, 1.0f, 1.0f, ColorTP);
    }
}
