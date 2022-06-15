using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePad : MonoBehaviour
{
    public Player myPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddForces(float x, float y, float z)
    {
        myPlayer.rb.AddForce(x, y, z);
    }
}
