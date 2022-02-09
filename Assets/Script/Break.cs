using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Plane")
        {
            audioSource.PlayOneShot(sound1);
        }
    }
}
