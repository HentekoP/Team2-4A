using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    GameObject hammer;
    GameObject bomb1;

    [SerializeField]
    private GameObject Select;

    public static int ItemNumber;
    public GameObject bombButton;
    public GameObject ButtonSelect;
    public GameObject bombSelect;
    public GameObject SwingText;
    public GameObject SettiText;
    public GameObject ExpText;
    bool bomb1Flg = true;
    bool HammerFlg = true;
    bool pushflg = false;
    bool ButtunFlg = true;
    bool BombIns = false;
    // Start is called before the first frame update
    void Start()
    {
        hammer = transform.GetChild(0).gameObject;
        bomb1 = transform.GetChild(1).gameObject;
        ButtonSelect.SetActive(false);
        SwingText.SetActive(false);
        SettiText.SetActive(false); 
        ExpText.SetActive(false);
        ItemNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bomb1Flg = reticleColor.GetBombFlg();
        HammerFlg = hamaaa.GetHammerFlag();
        ButtunFlg = reticleColor.GetButtonFlg();
        BombIns = reticleColor.BombInstantiate();
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
                    SwingText.SetActive(true);
                }
                else
                {
                    hammer.SetActive(false);
                    SwingText.SetActive(false);

                }
                bomb1.SetActive(false);
                bombButton.SetActive(false);
                SettiText.SetActive(false);
                ExpText.SetActive(false);
                if (BombIns == true)
                {
                    if (ButtunFlg == true)
                    {
                        ButtonSelect.SetActive(true);
                    }
                    else
                    {
                        ButtonSelect.SetActive(false);
                    }
                }
                else
                {
                    ButtonSelect.SetActive(false);
                }
                break;
            case 1:
                Select.transform.localPosition = new Vector3(-337.4f, -443f, 0f);
                hammer.SetActive(false);
                if (bomb1Flg == true)
                {
                    bomb1.SetActive(true);
                    bombSelect.SetActive(true);
                    SettiText.SetActive(true);
                }
                else
                {
                    bomb1.SetActive(false);
                    bombSelect.SetActive(false);
                    SettiText.SetActive(false);
                }
                bombButton.SetActive(false);
                SwingText.SetActive(false);
                ExpText.SetActive(false);
                if (BombIns == true)
                {
                    if (ButtunFlg == true)
                    {
                        ButtonSelect.SetActive(true);
                    }
                    else
                    {
                        ButtonSelect.SetActive(false);
                    }
                }
                else
                {
                    ButtonSelect.SetActive(false);
                }
                break;
            case 2:
                Select.transform.localPosition = new Vector3(-237.6f, -443f, 0f);
                hammer.SetActive(false);
                bomb1.SetActive(false);
                SettiText.SetActive(false);
                SwingText.SetActive(false);
                if (BombIns == true)
                {
                    if (ButtunFlg == true)
                    {
                        bombButton.SetActive(true);
                        ButtonSelect.SetActive(true);
                        ExpText.SetActive(true);
                    }
                    else
                    {
                        bombButton.SetActive(false);
                        ButtonSelect.SetActive(false);
                        ExpText.SetActive(false);
                    }
                }
                else
                {
                    ButtonSelect.SetActive(false);
                }
                break;
        }
    }
    public static int ItemNumberFlg()
    {
        return ItemNumber;
    }
}
