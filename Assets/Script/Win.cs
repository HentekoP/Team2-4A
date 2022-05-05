using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private float ChildCount;

    public float destroycounts;
    float clearcount;

    void Start()
    {
        ChildCount = this.transform.childCount;
        clearcount = ChildCount * destroycounts/* * 4*/;
        Debug.Log(clearcount);
    }

    void Update()
    {
        if (clearcount <= DestroyedPieceController.DestroyPieceCount)
        {
            //Debug.Log("クリア！");
        }
    }
}

/////////////////////////////////////////////////////////////////////////////////////////
//
//現在はすべて雛形とする
//
/////////////////////////////////////////////////////////////////////////////////////////
