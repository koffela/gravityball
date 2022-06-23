using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPadMed : ForcePad
{
    [SerializeField] float rampForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Upon collision with the player, this GameObject will give a significant speed boost
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            AddForces(0f, 0f, rampForce);
        }
    }
}
