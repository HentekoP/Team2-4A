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
    private float walkSpeed = 3.5f;
    [SerializeField]
    private float runSpeed = 6.5f;
    private bool runFlag = false;
    private Transform myCamera;
    [SerializeField]
    private float cameraRotateLimit = 75f;
    [SerializeField]
    private bool cameraRotForward = true;
    private Quaternion initCameraRot;
    [SerializeField]
    private float rotateSpeed = 1000f;
    private float xRotate;
    private float yRotate;
    [SerializeField]
    private float RstickSpeed = 1.8f;
    private Quaternion charaRotate;
    private Quaternion cameraRotate;
    private bool charaRotFlag = false;
    [SerializeField]
    private float jumpPower = 5f;
    [SerializeField]
    private float dashJumpPower = 6f;
    private bool jump;
    private bool Attack;
    private bool jumpFlg = false;
    Rigidbody rb;
    [SerializeField]
    private Image GameOver;
    public Text YouDead;
    public Text Continue;
    public Text BombDead;
    public Text Yes;
    public Text No;
    public float GameOverCount = 0.5f;
    public static bool ContinueFlg;
    public GameObject BGM;
    public AudioSource Dead;
    public static bool GameOverFlg;
    void Start()
    {
        cCon = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        myCamera = GetComponentInChildren<Camera>().transform;
        initCameraRot = myCamera.localRotation;
        charaRotate = transform.localRotation;
        cameraRotate = myCamera.localRotation;
        rb = GetComponent<Rigidbody>();
        GameOver.enabled = false;
        YouDead.enabled = false;
        Continue.enabled = false;
        BombDead.enabled = false;
        Yes.enabled = false;
        No.enabled = false;
        ContinueFlg = false;
        GameOverFlg = false;
    }
    void Update()
    {
        
        RotateChara();
        RotateCamera();

        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, -(Input.GetAxis("Vertical")));
        velocity = transform.TransformDirection(velocity);

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
        if (velocity.magnitude > 3f)
        {
            if (runFlag)
            {
                animator.SetFloat("speed", 4.1f);
            }
            else
            {
                animator.SetFloat("speed", 3.1f);
            }
        }
        else
        {
            animator.SetFloat("speed", 0f);
        }
        if (Input.GetButton("Jump"))
        {
            jump = true;
            if (runFlag && velocity.magnitude > 0f)
            {
                velocity.y += dashJumpPower;
            }
            else
            {
                velocity.y += jumpPower;
            }

        }
        else
        {
            jump = false;
        }
        if (jump == true)
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        cCon.Move(velocity * Time.deltaTime);
        
    }
    
    void RotateChara()
    {
        float yRotate = Input.GetAxis("Horizontal2") * RstickSpeed;
        charaRotate *= Quaternion.Euler(0f, yRotate, 0f);
        if (yRotate != 0f)
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
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("オマエはもう、死んでいる");
        GameOverFlg = true;
        BGM.SetActive(false);
        GameOver.color = new Color(255f, 0f, 0f, GameOverCount);
        GameOver.enabled = true;
        StartCoroutine(GameOverCoroutine());
        Time.timeScale = 0f;
    }
    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Dead.Play();
        GameOverCount = 0.6f;
        GameOver.color = new Color(255f, 0f, 0f, GameOverCount);
        yield return new WaitForSecondsRealtime(0.1f);
        GameOverCount = 0.7f;
        GameOver.color = new Color(255f, 0f, 0f, GameOverCount);
        yield return new WaitForSecondsRealtime(0.1f);
        GameOverCount = 0.8f;
        GameOver.color = new Color(255f, 0f, 0f, GameOverCount);
        yield return new WaitForSecondsRealtime(0.1f);
        GameOverCount = 0.9f;
        GameOver.color = new Color(255f, 0f, 0f, GameOverCount);
        yield return new WaitForSecondsRealtime(0.1f);
        GameOverCount = 1f;
        GameOver.color = new Color(255f, 0f, 0f, GameOverCount);
        yield return new WaitForSecondsRealtime(1f);
        YouDead.enabled = true;
        BombDead.enabled = true;
        yield return new WaitForSecondsRealtime(4f);
        ContinueFlg = true;
        Continue.enabled = true;
        Yes.enabled = true;
        No.enabled = true;
        
    }
    public static bool continueflg()
    {
        return ContinueFlg;
    }
    public static bool GetGameOverFlg()
    {
        return GameOverFlg;
    }
}



