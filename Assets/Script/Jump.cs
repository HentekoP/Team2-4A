using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    //[SerializeField] AudioClip[] se;
    public AudioSource source;

    void Awake()
    {
        // アタッチしたオーディオソースのうち1番目を使用する
        source = GetComponent<AudioSource>()/*[0]*/;
    }

    void OnTriggerEnter(Collider hit)
    {
        if (/*hit.gameObject == other.gameObject && */Input.GetButton("Jump"))
        {
            source.Play()/*OneShot(se[0])*/;
        }
    }
}
