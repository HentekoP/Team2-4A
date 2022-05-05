using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public GameObject stamp_S, stamp_A, stamp_B, stamp_C;
    public int Rank;
    float x = 10, y = 10;

    void Start()
    {
        stamp_S.SetActive(false);
        stamp_A.SetActive(false);
        stamp_B.SetActive(false);
        stamp_C.SetActive(false);
    }

    void Update()
    {
        RankSelect();
        if (Input.GetButtonDown("Y"))
        {
            SceneManager.LoadSceneAsync("Menu");
        }
    }

    void RankSelect()
    {
        switch (Rank)
        {
            case 1:
                stamp_S.SetActive(true);
                //stamp_Animation(stamp_S);
                break;
            case 2:
                stamp_A.SetActive(true);
                //stamp_Animation(stamp_A);
                break;
            case 3:
                stamp_B.SetActive(true);
                //stamp_Animation(stamp_B);
                break;
            case 4:
                stamp_C.SetActive(true);
                //stamp_Animation(stamp_C);
                break;
            default:
                break;
        }
    }

    //void stamp_Animation(GameObject obj)
    //{
    //    var tr = obj.gameObject.GetComponent<Transform>();
    //    while (tr.localScale.x >= 1.0f && tr.localScale.y >= 1.0f)
    //    {
    //        tr.localScale -= new Vector3(0.1f, 0.1f, 0);
    //    }
    //}
}
