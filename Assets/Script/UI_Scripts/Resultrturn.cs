using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resultrturn : MonoBehaviour
{
    public bool textflg;
    public static bool alphaflg;
    public Text text;
    public float textalpha;
    public float alphaMax = 1.0f;
    public float alphaMin = 0.0f;

    void Start()
    {
        textflg = false;
        alphaflg = false;
        textalpha = 0.0f;
        text = this.GetComponent<Text>();
        text.color = Color.clear;
    }

    void Update()
    {
        if(alphaflg == true)
        {
            TextAlpha();
            Result.rturnflg = true;
        }
    }

    void TextAlpha()
    {
        if (textflg == true)
        {
            text.color = new Color(255f, 0f, 0f, textalpha);
            textalpha = textalpha + 0.01f;
        }
        else
        {
            text.color = new Color(255f, 0f, 0f, textalpha);
            textalpha = textalpha - 0.01f;
        }

        if (textalpha >= alphaMax)
        {
            textflg = false;
        }
        else if (textalpha <= alphaMin)
        {
            textflg = true;
        }
    }
}
