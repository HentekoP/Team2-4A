using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject Pause_Panel,
                      Pause_Cursor;

    private void Start()
    {
        Pause_Panel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            Pause_Start();
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
            Time.timeScale = 0f;
            //　ポーズUIが表示されてなければ通常通り進行

            Pause_Select();
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    void Pause_Select()
    {
        var cursor_tr = Pause_Cursor.gameObject.GetComponent<Transform>();

        if (Input.GetAxis("Horizontal"))
        {

        }
    }
}
