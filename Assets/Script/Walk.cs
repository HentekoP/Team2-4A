using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Walk : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] AudioClip[] se;
    [SerializeField] bool randomizePitch = true;
    [SerializeField] float pitchRange = 0.1f;

    protected AudioSource source;

    private void Awake()
    {
        // アタッチしたオーディオソースのうち1番目を使用する
        source = GetComponents<AudioSource>()[0];
    }

    public void Playwalk()
    {
        if (randomizePitch)
            source.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);

        source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Sphereにぶつかれば、パーティクルを発生させる
        if (hit.gameObject.tag == "Ground" && PlayerController.GetjumpFlg() == true)
        {
            source.PlayOneShot(se[0]);
        }
    }
}
