using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Runtime.InteropServices.Guid("AF60DA75-A174-48B8-B6FA-60D9127A836F")]
public class DemoController : MonoBehaviour
{
    //public GameObject rayPosition;
    private float rayDistance;

    // Start is called before the first frame update
    void Start()
    {
        rayDistance = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        var direction = transform.forward;
        Vector3 rayPosition = transform.position + new Vector3(0.0f,0.0f,0.0f);
        Ray _ray = new Ray(rayPosition, direction);
        RaycastHit hit_info;
        Debug.DrawRay(rayPosition, direction * rayDistance, Color.red);

        if (Input.GetButton("x"))
        {

            if (Physics.Raycast(_ray, out hit_info, 1, 1 << LayerMask.NameToLayer("Destructible"), QueryTriggerInteraction.Ignore))
            {
                hit_info.collider.GetComponent<DestroyedPieceController>().cause_damage(_ray.direction * 150);

            }

        }
        
    }

  



}



