using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;
    float forwardDirection;
    float strafeDirection;
    public float movementSpeed= 5.0f;
    float verticalVelocity = 0;
    public float jumpSpeed = 10.0f;
    public float gravityMultiplier = 4.0f;
    public float mouseSensitivity = 2.0f;
    Camera firstPersonCam;
    float rotatePitch;
    float pitchRange = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        firstPersonCam = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
        Inputs();
        Movement();

    }

    void Inputs()
    {
        forwardDirection = Input.GetAxis("Vertical");
        strafeDirection = Input.GetAxis("Horizontal");
    }

    void Movement()
    {
        Vector3 direction = new Vector3(strafeDirection, 0, forwardDirection);
        direction = direction.normalized * movementSpeed;
        
        if(cc.isGrounded)
        {
            verticalVelocity = 0;
        }

        verticalVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            verticalVelocity = jumpSpeed;
        }

        direction.y = verticalVelocity;
        direction = transform.rotation * direction;
        cc.Move(direction * Time.deltaTime);
    }

    void CameraMovement()
    {
        float rotateYaw = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotateYaw, 0);

        rotatePitch += -Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotatePitch = Mathf.Clamp(rotatePitch, -pitchRange, pitchRange);
        //firstPersonCam.transform.Rotate(rotatePitch, 0, 0);
        firstPersonCam.transform.localRotation = Quaternion.Euler(rotatePitch, 0, 0);
    }
}
