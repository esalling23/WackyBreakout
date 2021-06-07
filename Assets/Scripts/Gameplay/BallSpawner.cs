using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public Ball ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBall() 
    {
        Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
    }
}
