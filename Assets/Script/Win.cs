using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene("Result");
        }
    }
}