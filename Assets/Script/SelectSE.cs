using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSE : MonoBehaviour
{
    public AudioClip select;
    public Title titleScript;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(titleScript.Menu_Num == 0)
        {
            audioSource.PlayOneShot(select);
        }
    }
}
