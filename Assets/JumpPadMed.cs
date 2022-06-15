using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadMed : ForcePad
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Upon collision with the player, this GameObject will bounce the player upward significantly
    private void OnTriggerEnter(Collider JumpPadMed)
    {
        AddForces(0f, myPlayer.jumpHeight*4, 0f);
    }
}
