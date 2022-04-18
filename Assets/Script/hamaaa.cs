using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamaaa : MonoBehaviour
{
    public GameObject effectPrefab;
    // ★★追加
    // 2種類目のエフェクトを入れるための箱
    public GameObject effectPrefab2;
    public int objectHP;
    private static bool HammerFlg = true;
    //private void OnTriggerEnter(Collider other)

    // SE用
    AudioSource audioSource;
    public AudioClip wall;
    public AudioClip glass;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (HammerFlg == true)
        {
            if (Input.GetButtonDown("x"))
            {      

                Debug.Log("Xボタンを押してるよ");
                if (GameObject.FindGameObjectWithTag("hammer"))
                {
                    Debug.Log("HPを減らしているはず");
                    // ★★追加
                    // オブジェクトのHPを１ずつ減少させる。
                    objectHP -= 1;
                    
                    // ★★追加
                    // もしもHPが0よりも大きい場合には（条件）
                    if (objectHP > 0)
                    {
                        //Destroy(other.gameObject);
                        //GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                        //Destroy(effect, 2.0f);
                    }
                    else
                    { // ★★追加  そうでない場合（HPが0以下になった場合）には（条件）

                        Debug.Log("どっか――ん");
                        GameObject[] objects = GameObject.FindGameObjectsWithTag("hammer");//オブジェクトのタグを見る
                        foreach (GameObject hammer in objects)
                        {
                            //Destroy(hammer);
                            GameObject.FindGameObjectWithTag("hammer").SetActive(false);
                            HammerFlg = false;
                        }
                    }
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            PlayeffectA(collision);
            audioSource.PlayOneShot(wall);
        }
        if (collision.gameObject.tag == "Glass")
        {
            PlayeffectB(collision);
            audioSource.PlayOneShot(glass);
        }
    }

    void PlayeffectA(Collision collision)
    {
        Instantiate(effectPrefab, this.transform.position, Quaternion.identity);
        effectPrefab.transform.position = collision.contacts[0].point;
    }

    void PlayeffectB(Collision collision)
    {
        Instantiate(effectPrefab2, this.transform.position, Quaternion.identity);
        effectPrefab2.transform.position = collision.contacts[0].point;
    }

    public static bool GetHammerFlag()
    {
        return HammerFlg;
    }
}