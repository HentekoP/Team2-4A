using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    bool Push_Flg = false; //連続入力防止用スイッチ
    bool End_Flg = false;
    int Menu_Num = 0;   //メニュー選択時の番号　0:リスタート 1:タイトル 2:終了
    Vector3 startPosition, targetPosition;
    [SerializeField] private GameObject pauseUI;
    private Vector3 velocity = Vector3.zero;
    public float time = 0F;

    void Start()
    {
        startPosition = new Vector3(1100, 140, 0);
        targetPosition = new Vector3(1100, 60, 0);
    }

    void Update()
    {
        Debug.Log(Menu_Num);
        float lsh = Input.GetAxis("Vertical");
        if (!End_Flg)
        {
            if (lsh == 1)
            {
                if (Push_Flg == false)
                {
                    Menu_Num++;
                    if (Menu_Num >= 2)
                    {
                        Menu_Num = 1;
                        Push_Flg = true;
                        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, time);
                    }
                }
            }
            else if (lsh == -1)
            {
                if (Push_Flg == false)
                {
                    Menu_Num--;
                    if (Menu_Num <= -1)
                    {
                        Menu_Num = 0;
                        Push_Flg = true;
                        transform.position = Vector3.SmoothDamp(transform.position, startPosition, ref velocity, time);
                    }
                }
            }
            else
            {
                Push_Flg = false;
            }
        }
        if (Input.GetButtonDown("A"))
        {
            
            if (SceneManager.GetActiveScene().name == "Title")
            {
                if (Menu_Num == 0)
                {
                    SceneManager.LoadScene("game");
                }
                else if (Menu_Num == 1)
                {
                    End_Flg = true;
                    pauseUI.SetActive(!pauseUI.activeSelf);
                    if (Input.GetButtonDown("A")) 
                    {
                        Application.Quit();
                    }
                }
            }
            else if (SceneManager.GetActiveScene().name == "game")
            {
                SceneManager.LoadScene("Title");
            }
        }
        if (Input.GetButtonDown("Menu"))
        {
            if (Debug.isDebugBuild)
            {
                //UnityEditor.EditorApplication.isPlaying = false;  //デバッグ用
            }

            Application.Quit();
        }
    }
}
