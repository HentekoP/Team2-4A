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
    public static bool change;
    static bool clearflg;

    void Start()
    {
        ChildCount = this.transform.childCount;
        clearcount = ChildCount * destroycounts;
        Debug.Log(clearcount);
        clear.SetActive(false);
        change = false;
        clearflg = false;
    }

    void Update()
    {
        if ((clearcount <= DestroyedPieceController.DestroyPieceCount))
        {
            //Time.timeScale = 0f;
            clearflg = true;
            clear.SetActive(true);
            if (change == true)
            {
                SceneManager.LoadSceneAsync("Result");
                Time.timeScale = 1f;
            }
        }
    }

    public static bool GetClearFlg()
    {
        return clearflg;
    }
}