using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public int rank;
    public Animator animator;
    public static bool rturnflg;

    void Start()
    {
        rturnflg = false;
    }

    void Update () {
        
        //GetComponentを用いてAnimatorコンポーネントを取り出す.
        animator = GetComponent<Animator>();
 
        //intパラメーターの値を設定する.
        animator.SetInteger("rank", rank);

        if(rturnflg == true && Input.GetButton("A"))
        {
            SceneManager.LoadSceneAsync("Menu");
        }
	}
}
