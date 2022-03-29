using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Small_Cube : MonoBehaviour
{
    public GameObject Cube;
    bool increase = false;

    void Update()
    {
        var scale = this.gameObject.GetComponent<Transform>();


        if (increase)   //破壊時
        {
            increase = false;
            if (scale.localScale.x >=  0.1f) {
                this.transform.localScale -= new Vector3
                    (this.transform.localScale.x / 2,
                    this.transform.localScale.y / 2,
                    this.transform.localScale.z / 2);
                GameObjectUtils.Clone(Cube);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
    public static class GameObjectUtils
    {
        /// <summary>
        /// 指定された GameObject を複製して返します
        /// </summary>
        public static GameObject Clone(GameObject go)
        {
            var clone = GameObject.Instantiate(go) as GameObject;
            clone.transform.parent = go.transform.parent;
            clone.transform.localPosition = go.transform.localPosition;
            clone.transform.localScale = go.transform.localScale;
            return clone;
        }
    }

    private void OnCollisionEnter(Collision collision)  
    {
        //ハンマーに当たった時
        if (collision.gameObject.tag == "hammer")
        {
            increase = true;
        }
    }
}
