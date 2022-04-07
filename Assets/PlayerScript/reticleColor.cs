﻿using System.Collections;
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
    int ItemNumber = 0;
    float Raycastlength = 0;
    float ColorTP;
    int bombcount = 1;
    bool pushcount = false;
    GameObject cd;
    GameObject cd2;
    GameObject Player;
    public GameObject BombButton;
    static bool buttonFlg = true;
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
        ItemNumber = ItemSelect.ItemNumberFlg();
        RaycastHit hit;
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
            Raycastlength = 2.5f;
            ColorTP = 0.0001f;
        }

        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, Raycastlength))
        {
            string hitTag = hit.collider.tag;

            pos = hit.normal / 4.5f + hit.collider.transform.position;
            if (cd2.activeSelf == true && bomb1Flg == true)
            {
                if (pushcount == false)
                {
                    if (Input.GetButtonDown("x") && bombcount > 0)
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
            if (cd.activeSelf == true || cd2.activeSelf == true)
            {
                if ((hitTag.Equals("Block")))
                {
                    ColorTP = 1.0f;
                }
                else
                {
                    ColorTP = 0.2f;
                }
            }

            if ((ItemNumber == 1 && bomb1Flg == false) || ItemNumber == 2)
            {
                if ((hitTag.Equals("bomb")))
                {
                    ColorTP = 1.0f;
                    if (Input.GetButtonDown("x"))
                    {
                        Debug.Log("thisone");
                        if (bomb1Flg == false)
                        {
                            bomb1Flg = true;
                        }
                        Destroy(hit.collider.gameObject);
                        bombcount++;
                    }
                }
            }
        }
        else
        {
            ColorTP = 0.2f;
        }
        aimPointImage.color = new Color(1.0f, 1.0f, 1.0f, ColorTP);
        if(BombButton.activeSelf == true)
        {
            var clones = GameObject.FindGameObjectsWithTag("bomb");
            if (Input.GetAxis("RT") == 1.0)
            {
                buttonFlg = false;
            }
        }
    }
    public static bool GetBombFlg()
    {
        return bomb1Flg;
    }
    public static bool GetButtonFlg()
    {
        return buttonFlg;
    }
}
