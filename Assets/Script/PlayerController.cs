using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _cController;
    public float Rotation = 180f;
    float moveSpeed = 3f;
    Transform _transform;
    Transform target;
    Vector3 _vector = Vector3.zero;
    float x, z;
    float x2;
    void Start()
    {
        target = GameObject.Find("BlueSuitFree01").transform;
        _cController = GetComponent<CharacterController>();
        _transform = transform;
    }
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        x2 = Input.GetAxis("Horizontal2");
        _vector = new Vector3(x, 0, -z);
        _vector = _transform.TransformDirection(_vector);
        _vector *= moveSpeed;
        _cController.Move(_vector * Time.deltaTime);

        target.Rotate(new Vector3(0, x2, 0));

    }
}
