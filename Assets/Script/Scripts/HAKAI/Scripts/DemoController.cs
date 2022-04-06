using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Runtime.InteropServices.Guid("AF60DA75-A174-48B8-B6FA-60D9127A836F")]
public class DemoController : MonoBehaviour
{
    public GameObject ObA;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(-90, 0, 0);
        Ray _ray = new Ray(ObA.transform.position, direction);
        RaycastHit hit_info;
      

        if (Input.GetButton("x"))
        {

            if (Physics.Raycast(_ray, out hit_info, 100, 1 << LayerMask.NameToLayer("Destructible"), QueryTriggerInteraction.Ignore))
            {
                hit_info.collider.GetComponent<DestroyedPieceController>().cause_damage(_ray.direction * 150);

            }

        }
        Debug.DrawRay(_ray.origin, _ray.direction * 1, Color.red, 5);
    }

  



}



