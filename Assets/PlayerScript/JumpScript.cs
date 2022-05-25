using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    bool jump;
    private Vector3 velocity;
    private Rigidbody rb;
    [SerializeField]
    private float jumpPower = 5f;
    [SerializeField]
    private float dashJumpPower = 6f;
    bool RUN;
    // Start is called before the first frame update
    void Start()
    {
        jump = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RUN = PlayerController.GetRunFlg();
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            if (RUN && velocity.magnitude > 0f)
            {
                rb.velocity = Vector3.up *  dashJumpPower;
            }
            else
            {
                rb.velocity = Vector3.up *  jumpPower;
            }
        }
        if (jump == true)
        {

        }
    }
}