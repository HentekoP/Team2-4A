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
        if (Input.GetButtonDown("A"))
        {
            if (SceneManager.GetActiveScene().name == "Title") {
                SceneManager.LoadScene("game");
            }
            else if (SceneManager.GetActiveScene().name == "game")
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
}
