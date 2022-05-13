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
    public static bool bomb1Flg;
    public Text TextFrame;
    int ItemNumber = 0;
    float Raycastlength = 0;
    float ColorTP;
    static int bombcount;
    bool pushcount = false;
    GameObject cd;
    GameObject cd2;
    GameObject Player;
    public GameObject BombButton;
    static bool buttonFlg;
    public static bool BombIns;
    bool ExpFlg;
    public GameObject KaisyuText;
    // Start is called before the first frame update
    void Start()
    {
        cd = transform.GetChild(0).gameObject;
        cd2 = transform.GetChild(1).gameObject;
        Player = GameObject.Find("BlueSuitFree01");
        bombcount = 3;
        buttonFlg = true;
        bomb1Flg = true;
        BombIns = false;
        KaisyuText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ItemNumber = ItemSelect.ItemNumberFlg();
        ExpFlg = Bom.ExpFlg();
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
        }

        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, Raycastlength))
        {
            string hitTag = hit.collider.tag;

            pos = hit.normal / 2f + hit.collider.transform.position;
            if (cd2.activeSelf == true && bomb1Flg == true)
            {
                if (pushcount == false)
                {
                    if (Input.GetButtonDown("X") && bombcount > 0 && (hitTag.Equals("Block")))
                    {
                        pushcount = true;
                        Instantiate(bombPrefab, pos, Player.transform.localRotation);
                        BombIns = true;
                        if(buttonFlg == false)
                        {
                            buttonFlg = true;
                        }
                        bombcount -= 1;
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

            if (ItemNumber == 1 || ItemNumber == 2)
            {
                if (hit.collider.tag == "bomb")
                {
                    ColorTP = 1.0f;
                    KaisyuText.SetActive(true);
                    if (Input.GetButtonDown("X"))
                    {
                        if (bomb1Flg == false)
                        {
                            bomb1Flg = true;
                        }
                        Destroy(hit.collider.gameObject);
                        bombcount++;
                    }
                }
                else
                {
                    KaisyuText.SetActive(false);
                }
            }
        }
        else
        {
            ColorTP = 0.2f;
        }
        if(BombButton.activeSelf == true)
        {
            var clones = GameObject.FindGameObjectsWithTag("bomb");
            if (GameObject.FindWithTag("bomb") == false && (Input.GetButtonDown("L1") || Input.GetButtonDown("R1"))&&bombcount <= 0)
            {
                buttonFlg = false;
            }
        }
        TextFrame.text = string.Format("{0:0}", bombcount);
        if (bombcount <= 0 && buttonFlg == false)
        {
            TextFrame.enabled = false;
        }
        else
        {
            TextFrame.enabled = true;
        }
        aimPointImage.color = new Color(1.0f, 1.0f, 1.0f, ColorTP);
    }
    public static bool GetBombFlg()
    {
        return bomb1Flg;
    }
    public static bool GetButtonFlg()
    {
        return buttonFlg;
    }
    public static int GetbombCount()
    {
        return bombcount;
    }
    public static bool BombInstantiate()
    {
        return BombIns;
    }
}
