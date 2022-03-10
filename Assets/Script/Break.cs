using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    Vector3 ookisa;
    public float life;
    void Start()
    {
        ookisa = gameObject.transform.localScale;
        life = 100f;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        float collisionForce = collision.impulse.magnitude / Time.fixedDeltaTime;

        if (collisionForce > 200.0f)
        {
            ookisa.x = ookisa.x / 2;
            ookisa.y = ookisa.y / 2;
            ookisa.z = ookisa.z / 2;
            gameObject.transform.localScale = ookisa;
        }
    }
}
