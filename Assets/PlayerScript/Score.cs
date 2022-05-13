using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI TSText;
    public TextMeshProUGUI TSText2;
    public TextMeshProUGUI BSText;
    public TextMeshProUGUI BSText2;
    public TextMeshProUGUI TotalSText;

    int TimeScore;
    int BombScore;
    static int TotalScore;
    float s1;
    float s2;
    float s3;
    float t1;
    float t2;
    float t3;
    float t4;
    float t5;
    
    // Start is called before the first frame update
    void Start()
    {
        TimeScore = 0;
        BombScore = 0;
        TotalScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeScore = Timer.EndTime();
        BombScore = reticleColor.GetbombCount();
        s3 = TimeScore / 100;
        s2 = (TimeScore / 10) % 10;
        s1 = TimeScore - (s3 * 100) - (s2 * 10);
        if (s3 > 0)
        {
            TSText.text = "<sprite=" + s3 + "><sprite=" + s2 + "><sprite=" + s1 + ">";
            TSText2.text = "<sprite=" + s3 + "><sprite=" + s2 + "><sprite=" + s1 + "><sprite=0><sprite=0>";
        }
        else if (s2 > 0)
        {
            TSText.text = "<sprite=" + s2 + "><sprite=" + s1 + ">";
            TSText2.text = "<sprite=" + s2 + "><sprite=" + s1 + "><sprite=0><sprite=0>";
        }
        else if(s1 > 0)
        {
            TSText.text = "<sprite=" + s1 + ">";
            TSText2.text = "<sprite=" + s1 + "><sprite=0><sprite=0>";
        }
        else
        {
            TSText.text = "<sprite=0>";
            TSText2.text = "<sprite=0>";
        }
        if (BombScore > 0)
        {
            BSText.text = "<sprite=" + BombScore + ">";
            BSText2.text = "<sprite=" + BombScore + "><sprite=0><sprite=0><sprite=0>";
        }
        else
        {
            BSText2.text = "<sprite=0>";
        }

        TotalScore = TimeScore + (BombScore * 10);
        Debug.Log(TotalScore);
        t5 = TotalScore / 100;
        t4 = (TotalScore / 10) % 10;
        t3 = TotalScore - (t5 * 100) - (t4 * 10);
        if (t5 > 0)
        {
            TotalSText.text = "<sprite=" + t5 + "><sprite=" + t4 + "><sprite=" + t3 + "><sprite=0><sprite=0>";
        }else if(t4 > 0)
        {
            TotalSText.text = "<sprite=" + t4 + "><sprite=" + t3 + "><sprite=0><sprite=0>";
        }else if(t3 > 0)
        {
            TotalSText.text = "<sprite=" + t3 + "><sprite=0><sprite=0>";
        }
        else
        {
            TotalSText.text = "<sprite=0>";
        }

        HighScore.NowScore = TotalScore;

        TotalScore = TotalScore * 100;
    }
    public static int GetTotalScore()
    {
        return TotalScore;
    }
}
