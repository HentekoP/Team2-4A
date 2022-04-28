using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    public Text Yes;
    public Text No;
    int ContinueNumber = 0;
    bool pushflg;
    bool Buttonflg;
    bool CFlg;
    bool SEflg;
    public AudioClip Select;
    public AudioClip Decision;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        pushflg = false;
        Buttonflg = false;
        SEflg = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CFlg = PlayerController.continueflg();
        if (CFlg == true && Buttonflg == false)
        {
            if (Input.GetAxis("Horizontal") == 1.0)
            {
                if (pushflg == false)
                {
                    pushflg = true;
                    if (SEflg == false)
                    {
                        if (++ContinueNumber > 1) ContinueNumber = 0;
                        audioSource.PlayOneShot(Select);
                        SEflg = true;
                    }
                }
            }
            else if (Input.GetAxis("Horizontal") == -1.0)
            {
                if (pushflg == false)
                {
                    pushflg = true;
                    if (SEflg == false)
                    {
                        if (--ContinueNumber < 0) ContinueNumber = 1;
                        audioSource.PlayOneShot(Select);
                        SEflg = true;
                    }
                }
            }
            else
            {
                pushflg = false;
                SEflg = false;
            }
            switch (ContinueNumber)
            {
                case 0:
                    Yes.color = new Color(255f, 255f, 255f);
                    No.color = new Color(0f, 0f, 0f);
                    if (Input.GetButtonDown("X") || Input.GetButtonDown("A"))
                    {
                        Buttonflg = true;
                        audioSource.PlayOneShot(Decision);
                        StartCoroutine(gameCoroutine());
                    }
                    break;
                case 1:
                    Yes.color = new Color(0f, 0f, 0f);
                    No.color = new Color(255f, 255f, 255f);
                    if (Input.GetButtonDown("X")|| Input.GetButtonDown("A"))
                    {
                        Buttonflg = true;
                        audioSource.PlayOneShot(Decision);
                        StartCoroutine(MenuCoroutine());
                    }
                    break;
            }
        }
    }
    IEnumerator gameCoroutine()
    {
        yield return new WaitForSecondsRealtime(1.6f);
        SceneManager.LoadScene("game");
        Time.timeScale = 1f;
    }
    IEnumerator MenuCoroutine()
    {
        yield return new WaitForSecondsRealtime(1.6f);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
