using System.Collections;
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
        if (rb.isKinematic == false)//Rigidbodyがfalseになったらコールチンを呼ぶ
        {

            StartCoroutine("HAKAI");
        }

    }

    private IEnumerator HAKAI()
    {
        yield return new WaitForSeconds(3.0f); //３秒後オブジェクトを消す   デバックで消したオブジェクトをコンソールに表示
        if (rb.isKinematic == false && Win.GetClearFlg() == false)
        {
            Destroy(gameObject);
            Debug.Log(gameObject);
        }

    }
}
