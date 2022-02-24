using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breake_Block : MonoBehaviour
{

    public GameObject Center_Block_1;
    public GameObject Center_Block_2;
    public GameObject Center_Block_3;
    public GameObject Center_Block_4;
    public GameObject Center_Block_5;
    public GameObject Center_Block_6;
    public GameObject Center_Block_7;
    public GameObject Center_Block_8;
    public GameObject Center_Block_9;

    int Breake_if1 = 0;
    int Breake_if2 = 0;
    int Breake_if3 = 0;
    int Breake_if4 = 0;
    int Breake_if5 = 0;
    int Breake_if6 = 0;
    int Breake_if7 = 0;
    int Breake_if8 = 0;
    int Breake_if9 = 0;

    int Breake_p = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var rb = this.GetComponent<Rigidbody>();
        var rb_c1 = Center_Block_1.GetComponent<Rigidbody>();
        var rb_c2 = Center_Block_2.GetComponent<Rigidbody>();
        var rb_c3 = Center_Block_3.GetComponent<Rigidbody>();
        var rb_c4 = Center_Block_4.GetComponent<Rigidbody>();
        var rb_c5 = Center_Block_5.GetComponent<Rigidbody>();
        var rb_c6 = Center_Block_6.GetComponent<Rigidbody>();
        var rb_c7 = Center_Block_7.GetComponent<Rigidbody>();
        var rb_c8 = Center_Block_8.GetComponent<Rigidbody>();
        var rb_c9 = Center_Block_9.GetComponent<Rigidbody>();

        if (rb_c1.isKinematic != true && Breake_if1 == 0)
        {
            Breake_if1++;
            Breake_p++;
        }
        if (rb_c2.isKinematic != true && Breake_if2 == 0)
        {
            Breake_if2++;
            Breake_p++;
        }
        if (rb_c3.isKinematic != true && Breake_if3 == 0)
        {
            Breake_if3++;
            Breake_p++;
        }
        if (rb_c4.isKinematic != true && Breake_if4 == 0)
        {
            Breake_if4++;
            Breake_p++;
        }
        if (rb_c5.isKinematic != true && Breake_if5 == 0)
        {
            Breake_if5++;
            Breake_p++;
        }
        if (rb_c6.isKinematic != true && Breake_if6 == 0)
        {
            Breake_if6++;
            Breake_p++;
        }
        if (rb_c7.isKinematic != true && Breake_if7 == 0)
        {
            Breake_if7++;
            Breake_p++;
        }
        if (rb_c8.isKinematic != true && Breake_if8 == 0)
        {
            Breake_if8++;
            Breake_p++;
        }
        if (rb_c9.isKinematic != true && Breake_if9 == 0)
        {
            Breake_if9++;
            Breake_p++;
        }

        if (Breake_p > 3)
        {
            rb.isKinematic = false;
        }

    }
}
