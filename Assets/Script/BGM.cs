using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    public GameObject Pause_Panel;
    public AudioSource audioSource;

    void Update()
    {
        if(Pause_Panel.activeSelf == true)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
    }
}
