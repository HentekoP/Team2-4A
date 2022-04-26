using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public RectTransform Title_cursor;
    public int Menu_Num = 0;   //メニュー選択時の番号　0:スタート 1:終了
    bool Push_Flg = false; //連続入力防止用スイッチ

    //　非同期動作で使用するAsyncOperation
    private AsyncOperation async;
    //　シーンロード中に表示するUI画面
    [SerializeField]
    private GameObject loadUI;
    //　読み込み率を表示するスライダー
    [SerializeField]
    private Slider slider;


    [SerializeField] private GameObject EndUI; //エンド画面
    int End_Menu_Num = 0;   //メニュー選択時の番号　0:タイトル 1:終了
    public RectTransform End_cursor;
    public bool End_flg = false;

    [SerializeField] AudioClip[] se;
    protected AudioSource source;

    private void Start()
    {
        // アタッチしたオーディオソースのうち1番目を使用する
        source = GetComponents<AudioSource>()[0];

        EndUI.SetActive(false);
    }

    private void Update()
    {
        //Lスティックの入力
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        if (!End_flg) {
            //下入力した場合
            if (v == 1)
            {
                if (Push_Flg == false)
                {
                    Push_Flg = true;
                    Menu_Num++;
                    source.PlayOneShot(se[0]);

                    //一番下より下入力をした場合
                    if (Menu_Num >= 2)
                    {
                        Menu_Num = 0;   //メニュー番号を一番上に変更
                        Title_cursor.position += new Vector3(0, 220, 0); //メニューの最初に移動
                    }
                    Title_cursor.position += new Vector3(0, -110, 0);   //カーソルを下に移動

                    Debug.Log("T" + Menu_Num);
                }
            }
            //上入力した場合
            else if (v == -1)
            {
                if (Push_Flg == false)
                {
                    Push_Flg = true;
                    Menu_Num--;
                    source.PlayOneShot(se[0]);

                    //一番上より上入力をした場合
                    if (Menu_Num <= -1)
                    {
                        Menu_Num = 1;   //メニュー番号を一番下に変更
                        Title_cursor.position += new Vector3(0, -220, 0);   //メニューの最後に移動
                    }
                    Title_cursor.position += new Vector3(0, 110, 0);    //カーソルを上に移動

                    Debug.Log("T" + Menu_Num);
                }
            }
            //入力をリセット
            else
            {
                Push_Flg = false;
            }


            if (Input.GetButtonDown("A"))
            {
                source.PlayOneShot(se[1]);

                if (Menu_Num == 0)
                {
                    NextScene();
                }
                else
                {
                    End_flg = true;
                }
            }
        }
        
        else if(End_flg)
        {
            Title_End();
        }
    }

    public void NextScene()
    {
        //　ロード画面UIをアクティブにする
        loadUI.SetActive(true);

        //　コルーチンを開始
        StartCoroutine("LoadData");
    }

    IEnumerator LoadData()
    {
        // シーンの読み込みをする
        async = SceneManager.LoadSceneAsync("Menu");

        //　読み込みが終わるまで進捗状況をスライダーの値に反映させる
        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
        }
    }

    void Title_End()
    {
        EndUI.SetActive(true);

        //　ポーズUIが表示されてる時は停止
        if (EndUI.activeSelf)
        {
            End_flg = true;
        }
        if (EndUI.activeSelf)
        {
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            //右入力した場合
            if (h == 1)
            {
                if (Push_Flg == false)
                {
                    Push_Flg = true;
                    End_Menu_Num--;

                    //一番下より下入力をした場合
                    if (End_Menu_Num <= -1)
                    {
                        End_Menu_Num = 1;   //メニュー番号を一番左に変更
                        End_cursor.position += new Vector3(-780, 0, 0); //メニューの最初に移動
                    }
                    End_cursor.position += new Vector3(390, 0, 0);   //カーソルを下に移動

                    Debug.Log("E" + End_Menu_Num);
                }
            }
            //左入力した場合
            else if (h == -1)
            {
                if (Push_Flg == false)
                {
                    Push_Flg = true;
                    End_Menu_Num++;

                    //一番上より上入力をした場合
                    if (End_Menu_Num >= 2)
                    {
                        End_Menu_Num = 0;   //メニュー番号を一番右に変更
                        End_cursor.position += new Vector3(780, 0, 0);   //メニューの最後に移動
                    }
                    End_cursor.position += new Vector3(-390, 0, 0);    //カーソルを上に移動

                    Debug.Log("E" + End_Menu_Num);
                }
            }
            //入力をリセット
            else
            {
                Push_Flg = false;
            }

            if (Input.GetButtonDown("A"))
            {
                source.PlayOneShot(se[1]);

                if (End_Menu_Num == 0)
                {
                    EndUI.SetActive(false);
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
