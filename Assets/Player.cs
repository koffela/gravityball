using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;
    public float jumpHeight = 250.0f;
    public Rigidbody rb;
    //public Collider jumpPad;
    //Get the rigidbody of the player
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z);

        movement = Vector3.ClampMagnitude(movement, 1);
        rb.AddForce(movement * speed);
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(0f, jumpHeight, 0f);
        }
    }

    

}
