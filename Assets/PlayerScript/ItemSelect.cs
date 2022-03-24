using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelect : MonoBehaviour
{
    GameObject hammer;
    GameObject bomb1;

    public static int ItemNumber = 0;
    bool bomb1Flg = true;
    bool HammerFlg = true;
    bool pushflg = false;
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
                break;
            case 1:
                hammer.SetActive(false);
                if (bomb1Flg == true)
                {
                    bomb1.SetActive(true);
                }
                else
                {
                    bomb1.SetActive(false);
                }
                break;
            case 2:
                hammer.SetActive(false);
                bomb1.SetActive(false);
                break;
        }
    }
}
