using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSE : MonoBehaviour
{
    public AudioSource SE;
    public AudioClip clip;

    void PlaySE()
    {
        SE.PlayOneShot(clip);
        Resultrturn.alphaflg = true;
    }
}
