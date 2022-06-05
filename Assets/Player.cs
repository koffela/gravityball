using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 3.0f;
    private float jumpHeight = 250.0f;
    private Rigidbody rb;
    //public Collider jumpPad;
    //Get the rigidbody of the player
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    /*In Unity, when using the default Input Manager, you’ll find an Input Axis for Horizontal and Vertical movement 
     * already set up and mapped to the WASD keys and arrow keys on the keyboard.
    */
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z);

        movement = Vector3.ClampMagnitude(movement, 1);
        rb.AddForce(movement * speed);
        if (Input.GetButtonDown("Jump"))
        {
            //Vector3 jump = new Vector3(0.0f, jumpHeight, 0.0f);
            //rb.velocity = new Vector3(0, jumpHeight, 0);
            rb.AddForce(0f, jumpHeight, 0f);
        }
        //transform.Translate(movement * speed * Time.deltaTime);
        //transform.Rotate(z, 0, x);
    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider jumpPad)
    {
        rb.AddForce(0f, jumpHeight*4, 0f);
    }

}
