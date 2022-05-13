using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject Pause_Panel;
    public RectTransform Pause_Cursor;

    //メニュー選択時の番号　0:ゲームに戻る 1:ステージ選択画面に戻る 2:ゲーム終了
    public int Menu_Num = 0;
    //連続入力防止用スイッチ
    bool Push_Flg = false;
    //ポーズメニュー選択用スイッチ
    bool Select_flg = false;

    [SerializeField] private GameObject Pause_EndPanel; //エンド画面

    //メニュー選択時の番号　0:戻る 1:終了
    public int Pause_EndNum = 0; 
    
    public RectTransform Pause_EndCursor;
    public bool End_flg = false;

    public AudioSource BGM;
    AudioSource SE;
    public AudioClip[] se;
    bool Clear;
    bool GameOver;

    private void Start()
    {
        Pause_Panel.SetActive(false);
        Pause_EndPanel.SetActive(false);
        SE = GetComponent<AudioSource>();
    }

    void Update()
    {
        Clear = Win.GetClearFlg();
        GameOver = PlayerController.GetGameOverFlg();
        if (Clear == false && GameOver == false)
        {
            //メニューボタンを押したら
            if (Input.GetButtonDown("Menu"))
            {
                Pause_Start();  //ポーズ画面に飛ぶようにする
            }
            if (Select_flg)
            {
                Pause_Select();
            }
        }
    }

    void Pause_Start()
    {
        Debug.Log("Menu_input!!");
        //　ポーズUIのアクティブ、非アクティブを切り替え
        Pause_Panel.SetActive(!Pause_Panel.activeSelf);

        //　ポーズUIが表示されてる時は停止
        if (Pause_Panel.activeSelf)
        {
            BGM.Pause();
            SE.PlayOneShot(se[0]);
            Time.timeScale = 0f;
            //　ポーズUIが表示されてなければ通常通り進行
            Select_flg = true;
        }
        else
        {
            BGM.UnPause();
            Pause_EndPanel.SetActive(false);
            Time.timeScale = 1f;
            Select_flg = false;
        }
    }

    void Pause_Select()
    {
        var cursor_tr = Pause_Cursor.gameObject.GetComponent<Transform>();
        //Lスティックの入力
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        if (!End_flg)
        {
            //下入力した場合
            if (v == 1)
            {
                if (Push_Flg == false)
                {
                    Push_Flg = true;
                    Menu_Num++;
                    SE.PlayOneShot(se[1]);
                    //一番下より下入力をした場合
                    if (Menu_Num >= 3)
                    {
                        Menu_Num = 0;   //メニュー番号を一番上に変更
                        Pause_Cursor.position += new Vector3(0, 600, 0); //メニューの最初に移動
                    }
                    Pause_Cursor.position += new Vector3(0, -200, 0);   //カーソルを下に移動

                    Debug.Log("P" + Menu_Num);
                }
            }
            //上入力した場合
            else if (v == -1)
            {
                if (Push_Flg == false)
                {
                    Push_Flg = true;
                    Menu_Num--;
                    SE.PlayOneShot(se[1]);
                    //一番上より上入力をした場合
                    if (Menu_Num <= -1)
                    {
                        Menu_Num = 2;   //メニュー番号を一番下に変更
                        Pause_Cursor.position += new Vector3(0, -600, 0);   //メニューの最後に移動
                    }
                    Pause_Cursor.position += new Vector3(0, 200, 0);    //カーソルを上に移動

                    Debug.Log("P" + Menu_Num);
                }
            }
            //入力をリセット
            else
            {
                Push_Flg = false;
            }


            if (Input.GetButtonDown("A"))
            {
                switch (Menu_Num)
                {
                    case 0:
                        BGM.UnPause();
                        Pause_Panel.SetActive(!Pause_Panel.activeSelf);
                        Time.timeScale = 1f;
                        Select_flg = false;
                        break;
                    case 1:
                        SE.PlayOneShot(se[2]);
                        SceneManager.LoadSceneAsync("Menu");
                        Time.timeScale = 1f;
                        Select_flg = false;
                        break;
                    case 2:
                        End_flg = true;
                        break;
                    default:
                        break;

                }
            }
        }

        else if (End_flg)
        {
            Pause_End();
        }
    }

    void Pause_End()
    {
        Pause_EndPanel.SetActive(true);

        //　ポーズUIが表示されてる時は停止
        if (Pause_EndPanel.activeSelf)
        {
            End_flg = true;
        }
        if (Pause_EndPanel.activeSelf)
        {
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            //右入力した場合
            if (h == 1)
            {
                if (Push_Flg == false)
                {
                    Push_Flg = true;
                    Pause_EndNum++;
                    SE.PlayOneShot(se[1]);
                    //一番下より下入力をした場合
                    if (Pause_EndNum >= 2)
                    {
                        Pause_EndNum = 0;   //メニュー番号を一番左に変更
                        Pause_EndCursor.position += new Vector3(-600, 360, 0); //メニューの最初に移動
                    }
                    Pause_EndCursor.position += new Vector3(300, -180, 0);   //カーソルを右に移動

                    Debug.Log("E" + Pause_EndNum);
                }
            }
            //左入力した場合
            else if (h == -1)
            {
                if (Push_Flg == false)
                {
                    Push_Flg = true;
                    Pause_EndNum--;
                    SE.PlayOneShot(se[1]);
                    //一番上より上入力をした場合
                    if (Pause_EndNum <= -1)
                    {
                        Pause_EndNum = 1;   //メニュー番号を一番右に変更
                        Pause_EndCursor.position += new Vector3(600, -360, 0);   //メニューの最後に移動
                    }
                    Pause_EndCursor.position += new Vector3(-300, 180, 0);    //カーソルを上に移動

                    Debug.Log("E" + Pause_EndNum);
                }
            }
            //入力をリセット
            else
            {
                Push_Flg = false;
            }

            if (Input.GetButtonDown("A"))
            {
                if (Pause_EndNum == 0)
                {
                    Pause_EndPanel.SetActive(false);
                    End_flg = false;
                }
                else
                {
                    //UnityEditor.EditorApplication.isPlaying = false;  //デバッグ用
                    Application.Quit();
                }
            }
        }
    }
}
