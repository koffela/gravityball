using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;
    public float jumpHeight = 250.0f;
    public Rigidbody rb;

    //Get the rigidbody of the player
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //inputs from the keyboard that are set up by default
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //combine the inputs into one vector to be used next
        Vector3 movement = new Vector3(x, 0, z);

        //clamp inputs so that moving diagonal doesn't give player extra speed
        movement = Vector3.ClampMagnitude(movement, 1);
        rb.AddForce(movement * speed);

        //The player can jump using space, which is apparently aptly named "Jump"
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(0f, jumpHeight, 0f);
        }
    }
}
