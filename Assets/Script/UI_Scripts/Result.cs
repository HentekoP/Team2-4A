using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public int rank;
    public Animator animator;

    void Update () {
        
        //GetComponentを用いてAnimatorコンポーネントを取り出す.
        animator = GetComponent<Animator>();
 
        //intパラメーターの値を設定する.
        animator.SetInteger("rank", rank);
	}
}
