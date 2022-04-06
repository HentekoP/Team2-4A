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
        anim.Play("Hammer");
    }

    void Update()
    {
        if (Input.GetButtonDown("x"))
        {
            anim.Play("attack");
        }
    }

    public void SwingStart()
    {
        capsule.enabled = true;
    }

    public void SwingEnd()
    {
        anim.Play("NormalSword");
        capsule.enabled = false;
    }
}
