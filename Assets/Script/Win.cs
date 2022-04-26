using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private int ChildCount;

    void Start()
    {
        ChildCount = this.transform.childCount;
    }
}
