using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : ForcePad
{
    [SerializeField] float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Upon collision with the player, this GameObject will bounce the player upward significantly
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            AddForces(0f, 800f, 0f);
        }
    }
}
