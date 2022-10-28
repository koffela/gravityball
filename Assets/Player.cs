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
    bool touchingGrass = false;
    bool speedBooster = true;

    //Get the rigidbody of the player
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
	{
        //The player can jump using space, which is apparently aptly named "Jump"
        //The player can only jump while touching the ground (touch grass XD)
        if (Input.GetButtonDown("Jump") && touchingGrass == true)
        {
            rb.AddForce(0f, jumpHeight, 0f);
            touchingGrass = false;
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

        //might need an adjustment to player movement since player cannot move in midair now
        if(direction.magnitude >= 0.1f && touchingGrass == true)
		{
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //might need some extra work here using a clamp...
            //clamp inputs so that moving diagonal doesn't give player extra speed
            //movement = Vector3.ClampMagnitude(movement, 1) + cam.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //if the player is boosting and on the ground...
            //may need a raycast for the booster as well
            if(Input.GetButtonDown("speedbooster") && touchingGrass == true && speedBooster == true)
            {
                speed = speed * 3.0f;
                rb.AddForce(moveDir.normalized * speed);
                speedBooster = false;
                StartCoroutine(boosterReloadTimer());
            }
            //otherwise, normal movement
            else
            {
                rb.AddForce(moveDir.normalized * speed);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //gonna need a raycast so that the player cannot jump while in the air, since currently
        //there is a bug where the player's jump ability is reset anytime they touch ground,
        //which means it can be used in mid-air once, after touching an object
        if(col.gameObject.tag == "Ground")
        {
            touchingGrass = true;
        }
    }

    IEnumerator boosterReloadTimer()
    {
        //the duration of the boost
        yield return new WaitForSeconds(1f);
        speed = speed / 3.0f;
        //boost reload timer
        yield return new WaitForSeconds(5);
        speedBooster = true;
    }
}
