using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Movement : MonoBehaviour
{
    Transform _main_Camera;
    CharacterController playerController;
    bool LockCursor = true;

    [SerializeField] float speed = 15f, gravity = -9.8f,sensitivity = 1f;
    Vector3 velocity;
    public float turnSmoothVelocity, turnSmoothTime = 0.1f;

    void Start()
    {
        if (LockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        _main_Camera = GetComponentInChildren<Camera>().transform;
        playerController = GetComponentInChildren<CharacterController>();
        
    }

    void Update()
    {
        moveInputs();
    }

    public void moveInputs()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        float targetRotation = _main_Camera.transform.eulerAngles.y;
        transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);

        Vector3 move_Dir = transform.right * x + transform.forward * z;
        playerController.Move(move_Dir * speed * Time.deltaTime);

        if (!playerController.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            playerController.Move(velocity * Time.deltaTime);
        }
        else velocity.y = 0f;
        _main_Camera.transform.position = transform.position;

    }
}
