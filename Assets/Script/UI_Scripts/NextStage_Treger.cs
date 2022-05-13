using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage_Treger : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] se;
    protected AudioSource source;
    bool grab;

    void Start()
    {
        // アタッチしたオーディオソースのうち1番目を使用する
        source = GetComponents<AudioSource>()[0];
    }
    void Update()
    {
        grab = moveItemScript2.GetGrabFlg();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && grab == true)
        {
            source.PlayOneShot(se[0]);

            SceneManager.LoadScene("game");
           
        }
    }
}
