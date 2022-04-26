using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI Timer_txt;


    void Start()
    {
        Timer_txt.text = "<sprite=0><sprite=0>:<sprite=0><sprite=0>";
    }
    // Update is called once per frame
    void Update()
    {

    }
}
