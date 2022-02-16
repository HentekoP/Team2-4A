using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController cCon;
    private Vector3 velocity;
    private Animator animator;
    [SerializeField]
    private float walkSpeed = 5f;
    [SerializeField]
    private float runSpeed = 10f;
    private bool runFlag = false;
    private Transform myCamera;
    [SerializeField]
    private float cameraRotateLimit = 30f;
    [SerializeField]
    private bool cameraRotForward = true;
    private Quaternion initCameraRot;
    [SerializeField]
    private float rotateSpeed = 2f;
    private float xRotate;
    private float yRotate;
    [SerializeField]
    private float RstickSpeed = 2f;
    private Quaternion charaRotate;
    private Quaternion cameraRotate;
    private bool charaRotFlag = false;
    void Start()
    {
        cCon = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        myCamera = GetComponentInChildren<Camera>().transform;
        initCameraRot = myCamera.localRotation;
        charaRotate = transform.localRotation;
        cameraRotate = myCamera.localRotation;
    }
    void Update()
    {
        RotateChara();
        RotateCamera();

        
            velocity = Vector3.zero;
            velocity = (transform.forward * -(Input.GetAxis("Vertical")) + transform.right * Input.GetAxis("Horizontal")).normalized;

        float speed = 0f;
            if (Input.GetButton("Run"))
            {
                runFlag = true;
                speed = runSpeed;
            }
            else
            {
                runFlag = false;
                speed = walkSpeed;
            }
            velocity *= speed;

        if (velocity.magnitude > 0f || charaRotFlag)
        {
            if (runFlag = true && charaRotFlag)
            {
                animator.SetFloat("speed", 2.1f);
            }
            else
            {
                animator.SetFloat("speed", 1f);
            }
        }
        else
        {
            animator.SetFloat("speed", 0f);
        }



        velocity.y += Physics.gravity.y * Time.deltaTime;
        Debug.Log(velocity);
        cCon.Move(velocity * Time.deltaTime);
    }
    void RotateChara()
    {
        float yRotate = Input.GetAxis("Horizontal2") * RstickSpeed;
        charaRotate *= Quaternion.Euler(0f, yRotate, 0f);
        if(yRotate != 0f)
        {
            charaRotFlag = true;
        }
        else
        {
            charaRotFlag = false;
        }
        transform.localRotation = Quaternion.Slerp(transform.localRotation, charaRotate, rotateSpeed * Time.deltaTime);

    }
    void RotateCamera()
    {
        float xRotate = Input.GetAxis("Vertical2") * RstickSpeed;
        if (cameraRotForward)
        {
            xRotate *= -1;
        }
        cameraRotate *= Quaternion.Euler(xRotate, 0f, 0f);
        var resultYRot = Mathf.Clamp(Mathf.DeltaAngle(initCameraRot.eulerAngles.x, cameraRotate.eulerAngles.x), -cameraRotateLimit, cameraRotateLimit);
        cameraRotate = Quaternion.Euler(resultYRot, cameraRotate.eulerAngles.y, cameraRotate.eulerAngles.z);
        myCamera.localRotation = Quaternion.Slerp(myCamera.localRotation, cameraRotate, rotateSpeed * Time.deltaTime);
    }
}
