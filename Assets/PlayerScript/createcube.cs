using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createcube : MonoBehaviour
{
    public GameObject prefabObj;

    public Transform parentTran;

    public Material matCyan;
    public Material matYellow;
    public Material matBulue;
    // Start is called before the first frame update
    void Start()
    {
        CreateBlockObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateBlockObject()
    {
        int row = 5;
        int High = 5;
        int column = 20;
        float xoffset = 0.2f;
        float yoffset = 0.1f;
        float zoffset = 0.1f;

        for(int h = 0; h < row; h++)
        {
            for(int i = 0;i < column; i++)
            {
                for(int j = 0; j < High; j++)
                {
                    GameObject obj = Instantiate(prefabObj, Vector3.zero, Quaternion. identity);
                    obj.transform.SetParent(parentTran);
                    float xPos = xoffset * h;
                    float yPos = yoffset * i;
                    float zPos = zoffset * j;
                    obj.transform.localPosition = new Vector3(xPos, yPos, zPos);

                    int materialID = Random.Range(0, 3);
                    Material mat = matCyan;
                    switch (materialID)
                    {
                        case 1:
                            mat = matBulue;
                            break;
                        case 2:
                            mat = matYellow;
                            break;
                    }
                    obj.GetComponent<MeshRenderer>().material = mat;
                }
            }
        }
    }
}
