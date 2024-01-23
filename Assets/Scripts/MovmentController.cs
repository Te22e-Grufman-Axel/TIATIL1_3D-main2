using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovmentController : MonoBehaviour
{
    [SerializeField]
    float speed = 5;

    [SerializeField]
    float jumpForce = 10;

    [SerializeField]
    float gravityMultiplier = 4;

    Vector2 inputVector = Vector2.zero;
    CharacterController CharacterController;
    
    float velocityY = 0;

    bool jumpPressed = false;

    void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 movment = transform.right * inputVector.x + 
                        transform.forward * inputVector.y;

    movment *= speed;

    if(CharacterController.isGrounded)
    {
        velocityY = -1f;

        if(jumpPressed)
        {
            velocityY = jumpForce;
        }
    }

    velocityY += Physics.gravity.y * gravityMultiplier * Time.deltaTime;

    movment.y = velocityY;

    CharacterController.Move(movment*Time.smoothDeltaTime);
    jumpPressed = false;
    }

    void OnMove(InputValue value) => inputVector = value.Get<Vector2>();

    void OnJump(InputValue value) => jumpPressed = true;

}
