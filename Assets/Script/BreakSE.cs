using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakSE : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        float tri = Input.GetAxis("RT");

        if (tri == 1.0f && (GameObject.FindWithTag("bomb").activeInHierarchy == true))
        {
            audioSource.PlayOneShot(sound2);
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
