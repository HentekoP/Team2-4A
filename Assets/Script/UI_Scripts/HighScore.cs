using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI HighSText;

    float t1;
    float t2;
    float t3;
    public int HighestScore = 0;
    public static int NowScore;

    public GameObject rankimage_S;
    public GameObject rankimage_A;
    public GameObject rankimage_B;
    public GameObject rankimage_C;

    public static int HighestRank = 0;

    void Start()
    {
        if (NowScore > HighestScore)
        {
            HighestScore = NowScore;
        }
    }

    void Update()
    {
        t1 = HighestScore / 100;
        t2 = (HighestScore / 10) % 10;
        t3 = HighestScore - (t1 * 100) - (t2 * 10);
        if (t1 > 0)
        {
            HighSText.text = "<sprite=" + t1 + "><sprite=" + t2 + "><sprite=" + t3 + "><sprite=0><sprite=0>";
        }
        else if (t2 > 0)
        {
            HighSText.text = "<sprite=" + t2 + "><sprite=" + t3 + "><sprite=0><sprite=0>";
        }
        else if (t3 > 0)
        {
            HighSText.text = "<sprite=" + t3 + "><sprite=0><sprite=0>";
        }
        else
        {
            HighSText.text = "<sprite=0>";
        }

        switch (HighestRank)
        {
            case 0:
                rankimage_S.SetActive(false);
                rankimage_A.SetActive(false);
                rankimage_B.SetActive(false);
                rankimage_C.SetActive(false);
                break;

            case 1:
                rankimage_S.SetActive(true);
                rankimage_A.SetActive(false);
                rankimage_B.SetActive(false);
                rankimage_C.SetActive(false);
                break;

            case 2:
                rankimage_S.SetActive(false);
                rankimage_A.SetActive(true);
                rankimage_B.SetActive(false);
                rankimage_C.SetActive(false);
                break;

            case 3:
                rankimage_S.SetActive(false);
                rankimage_A.SetActive(false);
                rankimage_B.SetActive(true);
                rankimage_C.SetActive(false);
                break;

            case 4:
                rankimage_S.SetActive(false);
                rankimage_A.SetActive(false);
                rankimage_B.SetActive(false);
                rankimage_C.SetActive(true);
                break;
        }
    }
}
