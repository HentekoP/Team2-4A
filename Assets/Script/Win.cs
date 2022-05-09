using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    private float ChildCount;

    public float destroycounts;
    float clearcount;
    public GameObject clear;

    void Start()
    {
        ChildCount = this.transform.childCount;
        clearcount = ChildCount * destroycounts/* * 4*/;
        Debug.Log(clearcount);
        clear.SetActive(false);
    }

    void Update()
    {
        if (clearcount <= DestroyedPieceController.DestroyPieceCount)
        {
            //SceneManager.LoadScene("Result");
            clear.SetActive(true);

        }
    }
}