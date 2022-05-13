using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript2 : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Color defaultColor;
    Color defaultColor_Transparent;

    public bool ray = false;
    public bool trigStay = false;

    public bool grab = false;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        defaultColor = meshRenderer.material.GetColor("_BaseColor");
        defaultColor_Transparent = defaultColor;
        defaultColor_Transparent.a = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((grab & !ray) || (grab && ray && trigStay))
        {
            meshRenderer.material.SetColor("_BaseColor", Color.red);

            //meshRenderer.material.SetColor("_BaseColor", defaultColor_Transparent);           
        }
        else
        {
            meshRenderer.material.SetColor("_BaseColor", defaultColor);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        trigStay = true;
    }

    private void OnTriggerExit(Collider other)
    {
        trigStay = false;
    }
}