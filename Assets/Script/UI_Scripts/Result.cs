using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    static int rank;
    int TotalScore;
    int time;
    public Animator animator;
    public static bool rturnflg;

    void Start()
    {
        rank = 0;
        rturnflg = false;
    }

    void Update () {
        TotalScore = Score.GetTotalScore();
        time = Timer.EndTime();
        //GetComponentを用いてAnimatorコンポーネントを取り出す.
        animator = GetComponent<Animator>();
 
        if(TotalScore >= 9500)
        {
            rank = 1;
        }else if (7500 <= TotalScore && TotalScore < 9500)
        {
            rank = 2;
        }else if(4000 <= TotalScore && TotalScore < 7500)
        {
            rank = 3;
        }else if(TotalScore < 4000 || time == 0)
        {
            rank = 4;
        }

        HighScore.HighestRank = rank;

        //intパラメーターの値を設定する.
        animator.SetInteger("rank", rank);

        if(rturnflg == true && Input.GetButton("A"))
        {
            SceneManager.LoadSceneAsync("Menu");
        }
	}
}
