using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage_Treger : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] se;
    protected AudioSource source;

    void Start()
    {
        // アタッチしたオーディオソースのうち1番目を使用する
        source = GetComponents<AudioSource>()[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            source.PlayOneShot(se[0]);

            SceneManager.LoadSceneAsync("game");
        }
    }
}
