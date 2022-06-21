using UnityEngine;

public class MovingPlatform : ForcePad
{
    [SerializeField] float distanceToCover;
    [SerializeField] float speed;

    private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        //get the starting position of the object
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //store the position of the object
        Vector3 v = startingPosition;
        //change the vector of the object with time and using a sine wave
        v.x += distanceToCover * Mathf.Sin(Time.time * speed);
        //move the object's actual position
        transform.position = v;
    }
}
