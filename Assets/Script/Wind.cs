using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float coefficient;   // 空気抵抗係数
    public Vector3 velocity;    // 風速

    private void Update()
    {
        velocity = new  Vector3(Random.Range(-5.0f, 5.0f),0,0);
    }

    void OnTriggerStay(Collider col)
    {
        var rb = col.gameObject.GetComponent<Rigidbody>();
        if (rb == null)
        {
            return;
        }

        // 相対速度計算
        var relativeVelocity = velocity - rb.velocity;

        // 空気抵抗を与える
        rb.AddForce(coefficient * relativeVelocity);
    }
}
