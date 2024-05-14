using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4;
    [SerializeField] float sprintSpeed = 9;
    [SerializeField] float rollSpeed = 13;
    [SerializeField] float gravity = -10;
    [SerializeField] float jumpHeight = 3;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    bool isGrounded;
    Vector3 velocity;
    private bool ballMode = false;

    private PlayerInputsManager input;
    private CharacterController controller;
    private Animator animator;

    [SerializeField] Transform cameraFollowTarget;
    [SerializeField] GameObject mainCam;
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInputsManager>();
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     SwitchMode();
     if (ballMode)
        MoveBall();
     else
        MoveNormal();
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
        Quaternion rotation = Quaternion.Euler(xRotation,yRotation,0);
        cameraFollowTarget.rotation = rotation;
    }

    void MoveNormal()
    {
        float speed = 0;
        Vector3 inputDir = new Vector3(input.move.x,0,input.move.y);
        float targetRotation = 0;
        if (input.move != Vector2.zero)
        {
            speed = input.sprint ? sprintSpeed : moveSpeed;
            targetRotation = Quaternion.LookRotation(inputDir).eulerAngles.y + mainCam.transform.rotation.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0,targetRotation,0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation , 20 * Time.deltaTime);
            animator.SetFloat("speed", input.sprint? 2 : input.move.magnitude);
        }
        else
        {
             animator.SetFloat("speed", 0);
        }
        Vector3 targetDirection = Quaternion.Euler(0,targetRotation,0) * Vector3.forward;
        controller.Move(targetDirection * speed * Time.deltaTime);
    }

    void MoveBall()
    {
        float speed = 0;
        Vector3 inputDir = new Vector3(input.move.x,0,input.move.y);
        float targetRotation = 0;
        if (input.move != Vector2.zero)
        {
            speed = rollSpeed;
            targetRotation = Quaternion.LookRotation(inputDir).eulerAngles.y + mainCam.transform.rotation.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0,targetRotation,0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation , 20 * Time.deltaTime);
        }
        animator.SetFloat("rollSpeed",input.move.magnitude);
        Vector3 targetDirection = Quaternion.Euler(0,targetRotation,0) * Vector3.forward;
        controller.Move(targetDirection * speed * Time.deltaTime);
    }
    
    void SwitchMode()
    {
          if (input.switchMode)
        {
            ballMode = !ballMode;
            input.switchMode = false;
            animator.SetBool("ballMode",ballMode);
        }
    }

    void JumpAndGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, .2f , groundLayer);
        if (isGrounded)
        {
            if (input.jump && ballMode)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);
                input.jump = false;
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
      
        controller.Move(velocity * Time.deltaTime);
    }
}
