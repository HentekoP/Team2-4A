using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour
{
    Animation anim;
    CapsuleCollider capsule;

    void Start()
    {
        anim = GetComponent<Animation>();
        capsule = GetComponent<CapsuleCollider>();

        capsule.enabled = false;
        Debug.Log("animationなんてないはずがない。");
        anim.Play("NormalHammer");
    }

    void Update()
    {
        if (Input.GetButtonDown("x"))
        {
            anim.Play("SwingHammer");
        }
    }

    public void SwingStart()
    {
        capsule.enabled = true;
        Debug.Log("今読み込んだよ");
    }

    public void SwingEnd()
    {
        Debug.Log("今から終わるよ");
        anim.Play("NormalHammer");
        capsule.enabled = false;
    }
}
