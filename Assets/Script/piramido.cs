using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piramido : MonoBehaviour
{
    public GameObject Prefab;

    // Use this for initialization
    void Start()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Instantiate(Prefab, new Vector3(x * 1.5f, y * 1.5f, 1), Quaternion.identity);
            }
        }
    }

}