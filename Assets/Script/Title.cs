using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    bool Push_Flg = false; //連続入力防止用スイッチ
    Vector3 startPosition, targetPosition;
    private Vector3 velocity = Vector3.zero;
    public float time = 1F;

    void Start()
    {
        startPosition = new Vector3(1100, 140, 0);
        targetPosition = new Vector3(1100, 60, 0);
    }

    void Update()
    {
        float lsh = Input.GetAxis("Vertical");
        if (lsh == 1)
        {
            if (Push_Flg == false)
            {
                Push_Flg = true;
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, time);
            }
        }
        else if (lsh == -1)
        {
            if (Push_Flg == false)
            {
                Push_Flg = true;
                transform.position = Vector3.SmoothDamp(transform.position, startPosition, ref velocity, time);
            }
        }
        else
        {
            Push_Flg = false;
        }
    }
}
