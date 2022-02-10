using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform target;
    private CharacterController _cController;
    public float Rotation = 180f;
    float step;
    float moveSpeed = 3f;
    float x;
    float y;
    Transform _transform;
    Vector3 _vector;
    void Start()
    {
        target = GameObject.Find("BlueSuitFree01").transform;
        _cController = GetComponent<CharacterController>();
        _transform = transform;
    }
    void Update()
    {
        _vector.x = Input.GetAxis("Horizontal") * moveSpeed;
        _vector.z = Input.GetAxis("Vertical") * -moveSpeed;
        x = Input.GetAxis("Horizontal2");
        y = Input.GetAxis("Vertical2");

        _transform.LookAt(_transform.position + new Vector3(_vector.x, 0, _vector.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(x * Rotation, y * Rotation, 0), step);
        _cController.Move(_vector * Time.deltaTime);
    }
}
