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
    private static bool bomb1Flg = true;
    float Raycastlength = 0;
    float ColorTP;
    int bombcount = 1;
    bool pushcount = false;
    GameObject cd;
    GameObject cd2;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        cd = transform.GetChild(0).gameObject;
        cd2 = transform.GetChild(1).gameObject;
        Player = GameObject.Find("BlueSuitFree01");
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
            Raycastlength = 0f;
            ColorTP = 0.0001f;
        }
        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);


        if (Physics.Raycast(ray, out hit, Raycastlength))
        {
            string hitTag = hit.collider.tag;

            pos = hit.normal / 4.5f + hit.collider.transform.position;
            if (cd2.activeSelf == true && bomb1Flg == true)
            {
                if (pushcount == false)
                {
                    if (Input.GetButton("x") && bombcount > 0)
                    {
                        pushcount = true;
                        Instantiate(bombPrefab, pos, Player.transform.localRotation);
                        bombcount -= 1;
                        Debug.Log(bombcount);
                    }
                }
                else
                {
                    pushcount = false;
                }
                if (bombcount <= 0)
                {
                    cd2.SetActive(false);
                    bomb1Flg = false;
                }
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
    public static bool GetBombFlg()
    {
        return bomb1Flg;
    }
}
