using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject camera;
    private CharacterController _cController;
    private Animator animator;
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
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        x2 = Input.GetAxis("Horizontal2");
        if (_cController.isGrounded)
        {
            _vector = new Vector3(x, 0, -z);
            if (_vector.magnitude > 0.1f)
            {
                animator.SetFloat("speed", _vector.magnitude);
                _transform.LookAt(_transform.position + _vector);
            }
            else
            {
                animator.SetFloat("speed", 0f);
            }
        }
        _cController.Move(_vector * moveSpeed * Time.deltaTime);
        target.Rotate(new Vector3(0, x2, 0));

    }
}
