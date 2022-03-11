using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gawahakai : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
