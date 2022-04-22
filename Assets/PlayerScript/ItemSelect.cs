﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    GameObject hammer;
    GameObject bomb1;

    [SerializeField]
    private GameObject Select;

    public static int ItemNumber = 0;
    public GameObject bombButton;
    public GameObject ButtonSelect;
    public GameObject bombSelect;
    bool bomb1Flg = true;
    bool HammerFlg = true;
    bool pushflg = false;
    bool ButtunFlg = true;
    // Start is called before the first frame update
    void Start()
    {
        hammer = transform.GetChild(0).gameObject;
        bomb1 = transform.GetChild(1).gameObject;
        ButtonSelect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bomb1Flg = reticleColor.GetBombFlg();
        HammerFlg = hamaaa.GetHammerFlag();
        ButtunFlg = reticleColor.GetButtonFlg();
        if (Input.GetButton("R1"))
        {
            if (pushflg == false)
            {
                pushflg = true;
                if (++ItemNumber > 2) ItemNumber = 0;
            }
        }
        else if(Input.GetButton("L1"))
        {
            if (pushflg == false)
            {
                pushflg = true;
                if (--ItemNumber < 0) ItemNumber = 2;
            }
        }
        else
        {
            pushflg = false;
        }
        switch (ItemNumber)
        {
            case 0:
                Select.transform.localPosition = new Vector3(-437f, -443f, 0f);
                if (HammerFlg == true)
                {
                    hammer.SetActive(true);
                }
                else
                {
                    hammer.SetActive(false);
                }
                bomb1.SetActive(false);
                bombButton.SetActive(false);
                break;
            case 1:
                Select.transform.localPosition = new Vector3(-337.4f, -443f, 0f);
                hammer.SetActive(false);
                if (bomb1Flg == true)
                {
                    bomb1.SetActive(true);
                    bombSelect.SetActive(true);
                    bombButton.SetActive(false);
                    ButtonSelect.SetActive(false);
                }
                else
                {
                    bomb1.SetActive(false);
                    bombSelect.SetActive(false);
                    if (ButtunFlg == true)
                    {
                        bombButton.SetActive(true);
                        ButtonSelect.SetActive(true);
                    }
                    else
                    {
                        bombButton.SetActive(false);
                        ButtonSelect.SetActive(false);
                    }
                }
                break;
            case 2:
                Select.transform.localPosition = new Vector3(-237.6f, -443f, 0f);
                hammer.SetActive(false);
                bomb1.SetActive(false);
                bombButton.SetActive(false);
                break;
        }
    }
    public static int ItemNumberFlg()
    {
        return ItemNumber;
    }
}
