using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private float ChildCount;

    public float destroycounts;
    float clearcount;
    public static int DestroyPieceCount = 0;
    public static int DestroyPieceCount1 = 0;

    //public static bool countFlg;

    //private Rigidbody[] Child_rigidbody;

    void Start()
    {
        ChildCount = this.transform.childCount;
        clearcount = ChildCount * destroycounts;
        //Child_rigidbody = GetComponentsInChildren<Rigidbody>();
        Debug.Log(clearcount);
    }

    void Update()
    {
        //for (int i = 0; i < ChildCount; i++) {
        //    if (Child_rigidbody[i].isKinematic == false && DestroyedPieceController.count == false)
        //    {
        //        DestroyPieceCount++;

        //    }
        //}
        //if (clearcount <= DestroyPieceCount)
        //{
        //    //Debug.Log("クリア！");
        //}
        if (DestroyPieceCount1 < DestroyPieceCount)
        {
            Debug.Log(DestroyPieceCount);
            DestroyPieceCount1 = DestroyPieceCount;
        }
    }
}

/////////////////////////////////////////////////////////////////////////////////////////
//
//現在はすべて雛形とする
//
/////////////////////////////////////////////////////////////////////////////////////////
