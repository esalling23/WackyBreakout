﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles Ball behavior
/// </summary>
public class Ball : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField]
    float startingAngle = 20f;

    [SerializeField]
    int damage = 50;

    #region Properties

    public int Damage
    {
        get { return damage; }
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        body.AddForce(new Vector2(ConfigurationUtils.BallImpulseForce * Mathf.Cos(startingAngle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(startingAngle)), ForceMode2D.Force);
    }

    public void SetDirection(Vector2 direction)
    {
        // Set the velocity to the current speed (magnitude) times the new direction
        body.velocity = body.velocity.magnitude * direction;
    }

    /// <summary>
    /// Adds direction to bounces off the paddle, walls
    ///
    /// Original from https://answers.unity.com/questions/1687930/how-to-change-bouncing-direction.html
    /// Modifications made to fit my needs
    /// </summary>
    /// <param name="collision"></param>
    /// Left for learning purposes - this was originally written to prevent
    /// up-and-down forever bouncing w/o direction
    /// The `OnCollisionEnter2D` method in `Paddle.cs` was provided for the
    /// assignment for the more specific purpose as described in it's comments. 
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print("collided");

    //    // If the ball is bouncing straight up and down, let's add a new angle to it
    //    if (Mathf.Abs(body.velocity.x) <= 0.1 || Mathf.Abs(body.velocity.y) <= 0.1)
    //    {
    //        print(body.velocity);
    //        float angle = Random.Range(0, 20f);
    //        body.AddForce(new Vector2(ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
    //        ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle)), ForceMode2D.Force);
    //    }
    //}


    
}
