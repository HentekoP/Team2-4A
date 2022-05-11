using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    int rank;
    int TotalScore;
    int time;
    public Animator animator;
    public static bool rturnflg;

    void Start()
    {
        rturnflg = false;
    }

    void Start()
    {
        rank = 0;
    }

    void Update () {
        TotalScore = Score.GetTotalScore();
        time = Timer.EndTime();
        //GetComponentを用いてAnimatorコンポーネントを取り出す.
        animator = GetComponent<Animator>();
 
        if(TotalScore >= 10000)
        {
            rank = 1;
        }else if (8000 <= TotalScore && TotalScore < 10000)
        {
            rank = 2;
        }else if(4000 <= TotalScore && TotalScore < 8000)
        {
            rank = 3;
        }else if(TotalScore < 4000)
        {
            rank = 4;
        }

        //intパラメーターの値を設定する.
        animator.SetInteger("rank", rank);

        if(rturnflg == true && Input.GetButton("A"))
        {
            SceneManager.LoadSceneAsync("Menu");
        }
	}
}
