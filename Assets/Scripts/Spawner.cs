using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    // Balls to spawn every second
    public float spawnRate = 1.0f;

    public int maxBalls = 20;

    private float currentTime = 0;
    private float lastSpawn = 0;

    private float spawnAreaX;
    private float spawnAreaY;
    private Vector3 center;

    private Queue<GameObject> balls = new Queue<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        // Preload a few values that should never change
        var bounds = gameObject.GetComponent<Renderer>().bounds;

        spawnAreaX = bounds.size.x / 2;
        spawnAreaY = bounds.size.y / 2;
        center = bounds.center;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the current time
        currentTime += Time.deltaTime;

        // Figure out how many balls we need to spawn, if any
        var ballsNeeded = (int)((currentTime - lastSpawn) * spawnRate);

        while (ballsNeeded > 0)
        {
            CreateBall();
            lastSpawn = currentTime;
            ballsNeeded -= 1;
	    }
    }


    private void CreateBall()
    {
        // If we've hit the limit, clean up an older ball
        if (balls.Count >= maxBalls)
        {
            var doomedBall = balls.Dequeue();

            Destroy(doomedBall);
	    }

        // Pick a start position
        var startX = center.x + Random.Range(-spawnAreaX, spawnAreaX);
        var startY = center.x + Random.Range(-spawnAreaY, spawnAreaY);

        var startPos = new Vector3(startX, startY, transform.position.z);

        // Create the ball
        var ballGame = (GameObject)Instantiate(ballPrefab, startPos, Quaternion.identity);

        var ball = ballGame.GetComponent<BallMover>();

        // Set the target point
        var endX = Random.Range(-0.5f, 0.5f);
        var endY = Random.Range(-0.5f, 0.5f);

        ball.target = new Vector3(endX, endY, 0);

        // Determine if this is a hit or a miss, and set the flag
        ball.isHit = ball.target.magnitude <= 0.5f;

        // Keep track of this ball
        balls.Enqueue(ballGame);
    }
}
