using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages Paddle game object behavior
/// </summary>
public class Paddle : MonoBehaviour
{
    Rigidbody2D body;
    Vector3 position;
    float horizontalInput;
    float halfColliderWidth;
    const float BounceAngleHalfRange = 60f * Mathf.Deg2Rad;

    // Start is called before the first frame update
    void Start()
    {

        body = GetComponent<Rigidbody2D>();

        // Gets the width of the box collider component
        halfColliderWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //  Horizontal axis is right/left arrow or a + d keys
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0) 
        {
            position = transform.position;
            position.x += horizontalInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.fixedDeltaTime;

            // Calculate clamped position to keep paddle on screen
            position.x = CalculateClampedX(position.x);

            // Move paddle
            body.MovePosition((Vector2)position);
        }
    }

    private float CalculateClampedX(float newXPosition)
    {
        if (newXPosition <= ScreenUtils.ScreenLeft + halfColliderWidth)
        {
            return ScreenUtils.ScreenLeft + halfColliderWidth;
        }
        else if (newXPosition >= ScreenUtils.ScreenRight - halfColliderWidth)
        {
            return ScreenUtils.ScreenRight - halfColliderWidth;
        }

        return newXPosition;
    }

    /// <summary>
    /// Checks for a top collision vs on the side 
    /// </summary>
    /// <param name="coll"></param>
    /// <returns></returns>
    bool CheckTopCollision(Collision2D coll)
    {
        // Top collission?
        if (coll.GetContact(0).point.y >= transform.position.y + halfColliderWidth - 0.5f)
        {
            print("top collision");
            return true;
        }
        return false;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    ///
    /// Depending on the spot we hit the ball on the paddle, change the direction
    /// of the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        // Is this the ball?
        if (coll.gameObject.CompareTag("Ball") && CheckTopCollision(coll))
        {
            // calculate new ball direction
            // Calculate how far the ball hit from the center of the paddle
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }
}
