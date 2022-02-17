using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kowareru : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var rb = GetComponent<Rigidbody>();

        //isKinematicをオンにする
        rb.isKinematic = true;
    }
}
