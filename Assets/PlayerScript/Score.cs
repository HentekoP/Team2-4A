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

    int TimeScore;
    int BombScore;
    float s1;
    float s2;
    float s3;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        else
        {
            TSText.text = "<sprite=" + s2 + "><sprite=" + s1 + ">";
            TSText2.text = "<sprite=" + s2 + "><sprite=" + s1 + "><sprite=0><sprite=0>";
        }
        BSText.text = "<sprite=" + BombScore + ">";
        BSText2.text = "<sprite=" + BombScore + "><sprite=0><sprite=0><sprite=0>";
    }
}
