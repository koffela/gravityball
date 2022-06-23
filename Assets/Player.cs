using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;
    public float jumpHeight = 250.0f;
    public Rigidbody rb;
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    //Get the rigidbody of the player
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
	{
        //The player can jump using space, which is apparently aptly named "Jump"
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(0f, jumpHeight, 0f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
	{
        //inputs from the keyboard that are set up by default
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(x, 0f, z).normalized; 
        //combine the inputs into one vector to be used next
        //Vector3 movement = new Vector3(x, 0, z);
        if(direction.magnitude >= 0.1f)
		{
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //clamp inputs so that moving diagonal doesn't give player extra speed
            //movement = Vector3.ClampMagnitude(movement, 1) + cam.eulerAngles.y;
            //transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.AddForce(moveDir.normalized * speed);
        }
        
    }
}
