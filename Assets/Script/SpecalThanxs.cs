using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecalThanxs : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("A"))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
