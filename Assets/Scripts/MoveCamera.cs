using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    Vector3 startPosition;
    Quaternion startRotation;
    
    Vector3 currentPosition;
    Quaternion currentRotation;

    public Vector3 newPosition;
    public Quaternion newRotation;
    public bool GoToStart = true;

    void Awake()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 destination = GoToStart ? startPosition : newPosition;  // if (GoToStart == true)   destination = start;  else  destination = new;
        Quaternion angle = GoToStart ? startRotation : newRotation;     // if (GoToStart == true)   angle = start;        else  angle= new;
        while (destination != currentPosition && angle != currentRotation)
        {
            currentPosition = destination;
            currentRotation = angle;
        }
    }
}
