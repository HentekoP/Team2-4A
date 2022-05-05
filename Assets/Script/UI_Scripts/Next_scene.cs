using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Back"))
        {
            SceneManager.LoadScene("Title");
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
