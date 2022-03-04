using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy2 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {

        var rb = GetComponent<Rigidbody>();

        // 地面に衝突したら自オブジェクト削除
        if (collision.gameObject.name == "Plane")
        {
            Destroy(gameObject, 1f);

            // Playerと衝突したら、自オブジェクトとPlayerオブジェクトを削除
        }
        if (collision.gameObject.tag == "Block")
        {
            rb.isKinematic = false;
            // Playerと衝突したら、自オブジェクトとPlayerオブジェクトを削除
        }
    }
}
