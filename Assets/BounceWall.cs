using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceWall : ForcePad
{
    [SerializeField] float xForce;
    [SerializeField] float yForce;
    [SerializeField] float zForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            AddForces(xForce, yForce, zForce);
        }
    }
}
