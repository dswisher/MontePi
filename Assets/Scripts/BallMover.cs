using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    // The point where the ball should hit the board
    public Vector3 target;

    // True if this is a hit on the unit circle, false if outside the unit circle
    public bool isHit;

    // The speed of the ball
    [SerializeField] private float speed = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // If we've arrived, we're done
        if (transform.position.z >= 0)
        {
            return;
	    }

        // Move towards the target
        var step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
