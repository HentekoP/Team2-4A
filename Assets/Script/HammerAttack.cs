using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour
{
    Animation anim;
    CapsuleCollider capsule;

    public AudioClip swingSE;
    AudioSource audioSource;

    private float rayDistance;
    void Start()
    {
        anim = GetComponent<Animation>();
        capsule = GetComponent<CapsuleCollider>();
        audioSource = GetComponent<AudioSource>();

        rayDistance = 1.0f;

        capsule.enabled = false;
        Debug.Log("animationなんてないはずがない。");
        anim.Play("SwingSword");
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
        var direction = transform.forward;
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        Ray _ray = new Ray(rayPosition, direction);
        RaycastHit hit_info;
        Debug.DrawRay(rayPosition, direction * rayDistance, Color.red);

        if (Physics.Raycast(_ray, out hit_info, 1, 1 << LayerMask.NameToLayer("Destructible"), QueryTriggerInteraction.Ignore))
        {
            hit_info.collider.GetComponent<DestroyedPieceController>().cause_damage(_ray.direction * 15);

        }
    }

    public void SwingEnd()
    {
        Debug.Log("今から終わるよ");
        anim.Play("SwingSword");
        capsule.enabled = false;
    }

    public void SE()
    {
        audioSource.PlayOneShot(swingSE);
    }
}
