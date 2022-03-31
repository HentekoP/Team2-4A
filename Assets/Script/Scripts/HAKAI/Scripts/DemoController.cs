using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Runtime.InteropServices.Guid("AF60DA75-A174-48B8-B6FA-60D9127A836F")]
public class DemoController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit_info;

        if (Input.GetButton("joystick button 2"))
        {

            if (Physics.Raycast(_ray, out hit_info, 100, 1 << LayerMask.NameToLayer("Destructible"), QueryTriggerInteraction.Ignore))
            {
                hit_info.collider.GetComponent<DestroyedPieceController>().cause_damage(_ray.direction * 0);

            }

        }
        Debug.DrawRay(_ray.origin, _ray.direction * 10, Color.red, 5);
    }

  



}



