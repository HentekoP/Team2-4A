using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public readonly static SceneChange Instance = new SceneChange();

    public string referer = string.Empty;

    void Change()
    {
        SceneChange.Instance.referer = SceneManager.GetActiveScene().name;
        Win.change = true;
    }
}
