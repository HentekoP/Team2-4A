using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reticleColor : MonoBehaviour
{
    [SerializeField]
    private Image aimPointImage;

    Vector2 displayCenter;

    private Vector3 pos;

    [SerializeField]
    private GameObject bombPrefab;
    int bombcount = 1;
    // Start is called before the first frame update
    void Start()
    {
        displayCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);



        if(Physics.Raycast(ray,out hit, 1.4f))
        {
            string hitTag = hit.collider.tag;

            pos = hit.normal + hit.collider.transform.position;

            if (Input.GetButton("x")&& bombcount > 0)
            {
                Instantiate(bombPrefab, pos, Quaternion.identity);
                bombcount--;
            }
            if(bombcount < 0)
            {
                Destroy(bombPrefab);
            }
            if ((hitTag.Equals("Block")))
            {
                aimPointImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            else
            {
                aimPointImage.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
            }
        }
        else
        {
            aimPointImage.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        }
    }
}
