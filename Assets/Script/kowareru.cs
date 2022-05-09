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
    }

     void Update()
    {
       if (rb.isKinematic == true)
       {
            StartCoroutine("HAKAI");
       }
        
    }

    private IEnumerator HAKAI()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}
