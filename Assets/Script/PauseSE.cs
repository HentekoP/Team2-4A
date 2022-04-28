using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSE : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] clips;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
