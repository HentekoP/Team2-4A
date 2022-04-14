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

    public void Playjump()
    {
        source.PlayOneShot(se[0]);
    }
    
    public void Playlanding()
    {
        source.PlayOneShot(se[1]);
    }
}
