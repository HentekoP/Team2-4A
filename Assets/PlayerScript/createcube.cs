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
        int row = 10;
        int High = 10;
        int column = 30;
        float xoffset = 0.9f;
        float yoffset = 0.3f;
        float zoffset = 0.9f;
        float yR = 0;
        float count = 0;

        for(int h = 0; h < row; h++)
        {
            for(int i = 0;i < column; i++)
            {
                for(int j = 0; j < High; j++)
                {
                    if (0 < h && h < row - 1 && 0 < j && j < High - 1) { }
                    else
                    {
                        GameObject obj = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);
                        if (0 < j && j < High - 1) {
                            if (yR == 0 && count == 0)
                            {
                                yR = 90f;
                                transform.Rotate(0, yR, 0, Space.World);
                                count++;
                            }
                            else
                            {
                                yR = 0f;
                                transform.Rotate(0, yR, 0, Space.World);
                            }
                        } else
                        {
                            
                        }

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
}
