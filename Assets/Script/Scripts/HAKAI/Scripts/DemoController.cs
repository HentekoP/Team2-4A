using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Runtime.InteropServices.Guid("AF60DA75-A174-48B8-B6FA-60D9127A836F")]
public class DemoController : MonoBehaviour
{
    //public GameObject rayPosition;
    private float rayDistance;
    float f;
    // Start is called before the first frame update
    void Start()
    {
        rayDistance = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        f = Input.GetAxis("RT");

        if (Input.GetButton("x"))
        {
            Ataru();

        }
        if (f == 1.0)
        {
           bakuhatu();
        }
        
    }

  void Ataru()
    {
        var direction = transform.forward;
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        Ray _ray = new Ray(rayPosition, direction);
        RaycastHit hit_info;
        Debug.DrawRay(rayPosition, direction * rayDistance, Color.red);

        if (Physics.Raycast(_ray, out hit_info, 1, 1 << LayerMask.NameToLayer("Destructible"), QueryTriggerInteraction.Ignore))
        {
            hit_info.collider.GetComponent<DestroyedPieceController>().cause_damage(_ray.direction * 15);

        }
    }

    
    

    void bakuhatu()
    {
        var direction = transform.forward;
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        Ray _ray = new Ray(rayPosition, direction);
        RaycastHit hit_info;
        Debug.DrawRay(rayPosition, direction * rayDistance, Color.red);

        if (Physics.Raycast(_ray, out hit_info, 1, 1 << LayerMask.NameToLayer("Destructible"), QueryTriggerInteraction.Ignore))
        {
            hit_info.collider.GetComponent<DestroyedPieceController>().cause_damage(_ray.direction * 150);

        }
    }


    
}



