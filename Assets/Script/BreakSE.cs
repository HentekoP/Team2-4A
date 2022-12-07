using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakSE : MonoBehaviour
{
    public AudioClip Bom;
    public AudioClip HammerDestroyed;
    public AudioClip sound5;

    AudioSource audioSource;

    public hamaaa hammerScript;

    float tri;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        tri = Input.GetAxis("RT");

        if (tri == 1.0f && GameObject.FindWithTag("bomb") == true  && GameObject.FindWithTag("Switch") == true)
        {
            audioSource.PlayOneShot(Bom);
        }

        if (Input.GetButtonDown("X"))
        {
            if(hammerScript.objectHP == 0 && hamaaa.HammerFlg ==false)
            {
                audioSource.PlayOneShot(HammerDestroyed);
                hamaaa.HammerFlg = true;

            }
        }
    }
}
