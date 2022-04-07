using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakSE : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
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

        if (tri == 1.0f && (GameObject.FindWithTag("bomb")/*.activeInHierarchy*/ == true))
        {
            audioSource.PlayOneShot(sound2);
        }

        //if(hammerScript.objectHP >= 0)
        //{
        //    audioSource.PlayOneShot(sound3);
        //}
        if (Input.GetButtonDown("x"))
        {
            if (hammerScript.objectHP > 1)
            {
                audioSource.PlayOneShot(sound4);
            }
            if(hammerScript.objectHP == 1 && GameObject.FindWithTag("hammer") == true)
            {
                audioSource.PlayOneShot(sound3);

            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Plane")
        {
            audioSource.PlayOneShot(sound1);
        }
    }
}
