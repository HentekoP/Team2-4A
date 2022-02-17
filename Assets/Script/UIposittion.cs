using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIposittion : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;

    [SerializeField] Image text;
    GameObject selectedObj;



    public void UI()
    {
        selectedObj = eventSystem.currentSelectedGameObject.gameObject;
        transform.position = new Vector3(transform.position.x, selectedObj.transform.position.y, transform.position.z);

    }

}
