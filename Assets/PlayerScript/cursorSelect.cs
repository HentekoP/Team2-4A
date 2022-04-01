using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorSelect : MonoBehaviour
{
    public static int ItemNumber = 0;
    public RectTransform rect;
    bool pushflg = false;
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Input.GetButton("R1"))
        {
            if (pushflg == false)
            {
                pushflg = true;
                if (++ItemNumber > 2) ItemNumber = 0;
            }
        }
        else if (Input.GetButton("L1"))
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
                rect.localPosition = new Vector3(-332, -465, 0);
                break;
            case 1:
                rect.localPosition = new Vector3(-241, -465, 0);
                break;
            case 2:
                rect.localPosition = new Vector3(-161, -465, 0);
                break;
        }
    }
}
