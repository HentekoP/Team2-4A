using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour
{
    private CharacterController cCon;
    private Vector3 velocity;
    private Animator animator;
    private bool hammer;
    private bool hammerFlag = false;
    [SerializeField] Animator AnimationImage = null;
    private bool isHit;
    void Start()
    {
        cCon = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("x"))
        {
            Debug.Log("アニメ再生してほしい。");
            hammerFlag = true;
            animator.SetBool("hammer", true);
        }else{ 
            animator.SetBool("hammer", false); 
        }
    }
}
