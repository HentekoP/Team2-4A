using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kowareru : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //StartCoroutine("HAKAI");
    }

     void Update()
    {
       if (rb.isKinematic == false)
       {
            StartCoroutine("HAKAI");
       }
        
    }

    private IEnumerator HAKAI()
    {
        yield return new WaitForSeconds(3.0f);
        if (rb.isKinematic == false &&Win.GetClearFlg()==false)
        {
             Destroy(gameObject);
        }
       
    }
}
