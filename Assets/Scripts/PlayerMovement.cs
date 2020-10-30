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

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        Movement();

    }

    void Inputs()
    {
        forwardDirection = Input.GetAxis("Horizontal");
        strafeDirection = Input.GetAxis("Vertical");
    }

    void Movement()
    {
        Vector3 direction = new Vector3(strafeDirection, 0, forwardDirection);
        direction = direction.normalized * movementSpeed;
        cc.Move(direction * Time.deltaTime);

        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        direction.y = verticalVelocity;

        if (Input.GetButtonDown("Jump") && cc.isGrounded)
       // if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("Grounded");
            verticalVelocity = jumpSpeed;
        }

    }

}
