using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Material definition for an object */
public class ObjectMaterial : MonoBehaviour
{
    [SerializeField] public MaterialTypes MaterialType; //ObjectMaterialManagerからもらってきてる。

    private void OnCollisionEnter(Collision collision)
    {
        MeshCutterManager.Instance.DamageMesh(gameObject, collision.relativeVelocity.magnitude * 10);
    }
}


//ObjectMaterialManagerからもらった情報をもとに壊れ方を決めている。オブジェクトの壊れ方に違いが出る