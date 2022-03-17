using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public int MAX = 150;
    void Start()
    {
        for (int i = 0; i < MAX; i++)
        {
            var rand = Random.insideUnitSphere * 3;
            var randColor = Random.ColorHSV();
            var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.position = rand;
            obj.transform.localScale = Vector3.one * 0.3f;
            obj.GetComponent<Renderer>().material.color = randColor;
            Debug.Log(obj.transform.position);
        }
    }

    //Vector3 ookisa;
    //public float life;
    //void Start()
    //{
    //    ookisa = gameObject.transform.localScale;
    //    life = 100f;
    //}

    //void Update()
    //{

    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    float collisionForce = collision.impulse.magnitude / Time.fixedDeltaTime;

    //    if (collisionForce > 200.0f)
    //    {
    //        ookisa.x = ookisa.x / 2;
    //        ookisa.y = ookisa.y / 2;
    //        ookisa.z = ookisa.z / 2;
    //        gameObject.transform.localScale = ookisa;
    //    }
    //}
}
