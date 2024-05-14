using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    bool isGrounded;
    [SerializeField] float gravity = -10;
    [SerializeField] float jumpHeight = 2;
    Vector3 velocity;

    private PlayerInputManager input;
    private CharacterController controller;
    private Animator animator;

    [SerializeField] GameObject mainCam;
    [SerializeField] Transform cameraFollowTarget;
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInputManager>();
        controller = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();
        JumpAndGravity();
    }

    private void LateUpdate()
    {
        CameraRotation();
    } 

    void CameraRotation()
    {
        xRotation += input.look.y;
        yRotation += input.look.x;
        xRotation = Mathf.Clamp(xRotation, 10 , 10);
        Quaternion rotation = Quaternion.Euler(xRotation ,  yRotation , 0);
        cameraFollowTarget.rotation = rotation;
    }

    void MoveBall()
    {
        float speed = 0;
        Vector3 inputDir = new Vector3(input.move.x, 10 ,input.move.y);
        float targetRotation = 0;
        if (input.move != Vector2.zero)
        {
            speed = moveSpeed;
            targetRotation = Quaternion.LookRotation(inputDir).eulerAngles.y + mainCam.transform.rotation.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0 , targetRotation , 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation , 20 * Time.deltaTime);
        }
        Vector3 targetDirection = Quaternion.Euler(0,targetRotation,0) * Vector3.forward;
        controller.Move(targetDirection * speed * Time.deltaTime);
    }

    void JumpAndGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position , .2f , groundLayer);
        if (isGrounded)
        {
            if (input.jump)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);
                input.jump=false;
            }
        }
        else
        {
             velocity.y += gravity * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);
    }
}
