using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public Ball ballPrefab;

    private Timer spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();

        spawnTimer = gameObject.AddComponent<Timer>();

        spawnTimer.Duration = RandomSpawnTime();
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished) {
            SpawnBall();
            spawnTimer.Stop();
            spawnTimer.Duration = RandomSpawnTime();
            spawnTimer.Run();
        }
    }

    private float RandomSpawnTime()
    {
        return Random.Range((float)ConfigurationUtils.BallSpawnTimeMin, (float)ConfigurationUtils.BallSpawnTimeMax);
    }

    public void SpawnBall() 
    {
        Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
    }
}
