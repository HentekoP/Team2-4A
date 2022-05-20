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
    public static int StageNumber;

    public GameObject cautionText;

    void Start()
    {
        // アタッチしたオーディオソースのうち1番目を使用する
        source = GetComponents<AudioSource>()[0];
        StageNumber = 0;
        cautionText.gameObject.SetActive(false);
    }

    void Update()
    {
        grab = moveItemScript2.GetGrabFlg();

        if (grab == true)
        {
            cautionText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item") && grab == true)
        {
            cautionText.gameObject.SetActive(false);
            source.PlayOneShot(se[0]);
            StageNumber = 1;
            SceneManager.LoadScene("game");
        }

        if (other.CompareTag("Item2") && grab == true)
        {
            cautionText.gameObject.SetActive(false);
            source.PlayOneShot(se[0]);
            StageNumber = 2;
            SceneManager.LoadScene("game2");
        }
        
        if (grab == false)
        {
            source.PlayOneShot(se[1]);
            cautionText.gameObject.SetActive(true);
        }
    }

    public static int GetStageNumber()
    {
        return StageNumber;
    }
}
