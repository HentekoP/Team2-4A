using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    GameObject hammer;
    GameObject bomb1;


    public static int ItemNumber = 0;
    public GameObject bombButton;
    bool bomb1Flg = true;
    bool HammerFlg = true;
    bool pushflg = false;
    bool ButtunFlg = true;
    // Start is called before the first frame update
    void Start()
    {
        hammer = transform.GetChild(0).gameObject;
        bomb1 = transform.GetChild(1).gameObject;
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
                hammer.SetActive(false);
                if (bomb1Flg == true)
                {
                    bomb1.SetActive(true);
                    bombButton.SetActive(false);
                }
                else
                {
                    bomb1.SetActive(false);
                    if (ButtunFlg == true)
                    {
                        bombButton.SetActive(true);
                    }
                    else
                    {
                        bombButton.SetActive(false);
                    }
                }
                break;
            case 2:
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
