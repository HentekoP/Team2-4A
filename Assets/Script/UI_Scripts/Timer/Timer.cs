using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    //　タイマーを表示するテキスト
    public TextMeshProUGUI timerText;

    int s1,s2,s3;
    public float totalTime;
    static int seconds;
    public GameObject clear;

    private void Start()
    {
        s1 = 0;
        s2 = 0;
        s3 = 0;
        seconds = (int)totalTime;
    }

    private void Update()
    {
        if (seconds > 0) {
            totalTime -= Time.deltaTime;
            seconds = (int)totalTime;
            s3 = seconds / 100;
            s2 = (seconds / 10) % 10;
            s1 = (seconds / 1) - (s3 * 100) - (s2 * 10);
            timerText.text = "<sprite=" + s3 + "><sprite=" + s2 + "><sprite=" + s1 + ">";
        }
        else
        {
            s3 = 0;
            s2 = 0;
            s1 = 0;
            timerText.text = "<sprite=" + s3 + "><sprite=" + s2 + "><sprite=" + s1 + ">";

            Time.timeScale = 0f;
            clear.SetActive(true);
            if (Win.change == true)
            {
                SceneManager.LoadSceneAsync("Result");
                Time.timeScale = 1f;
            }
        }
    }
    public static int EndTime()
    {
        return seconds;
    }
}
