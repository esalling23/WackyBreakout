using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private Ball ballPrefab;

    // Spawn utils
    private Ball spawnedBall;
    private Vector2 topRightPos;
    private Vector2 bottomLeftPos;
    private bool retrySpawn = false;

    private Timer spawnTimer;
    // Start is called before the first frame update

    #endregion

    #region Methods
    void Start()
    {
        // Setup spawn timer for random spawning
        spawnTimer = gameObject.AddComponent<Timer>();
        // Spawn a ball right away
        SpawnBall();

        // Find the bounds of the spawn location
        float halfHeight = spawnedBall.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        float halfWidth = spawnedBall.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        topRightPos = new Vector2(spawnedBall.transform.position.y + halfHeight, spawnedBall.transform.position.x + halfWidth);
        bottomLeftPos = new Vector2(spawnedBall.transform.position.y - halfHeight, spawnedBall.transform.position.x - halfWidth);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GameOver && (retrySpawn || spawnTimer.Finished))
        {
            retrySpawn = false;
            SpawnBallWithChecks();
        }
    }

    /// <summary>
    /// Gets a random spawn time between the provided min/max config values
    /// </summary>
    /// <returns>A float between min/max spawn time</returns>
    private float RandomSpawnTime()
    {
        return Random.Range((float)ConfigurationUtils.BallSpawnTimeMin, (float)ConfigurationUtils.BallSpawnTimeMax);
    }

    /// <summary>
    /// Instantiates a new ball
    /// </summary>
    private void SpawnBall() 
    {
        spawnedBall = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
        SetTimer();
    }

    /// <summary>
    /// Sets timer
    /// 1. Stops timer
    /// 2. Set duration to random time
    /// 3. Run timer
    /// </summary>
    private void SetTimer() 
    {
        // Reset timer
        spawnTimer.Stop();
        spawnTimer.Duration = RandomSpawnTime();
        spawnTimer.Run();
    }

    /// <summary>
    /// Spawns a new ball with checks for collider
    /// Also resets timer on spawn
    /// </summary>
    public void SpawnBallWithChecks()
    {
        // Check if the spawn area currently has something in it
        Collider2D colliding = Physics2D.OverlapArea(topRightPos, bottomLeftPos);

        // Set to retry this spawn if the spawn area is filled
        if (colliding)
        {
            retrySpawn = true;
        }
        else
        {
            // Otherwise spawn a new ball
            SpawnBall();
        }
    }

    #endregion
}
