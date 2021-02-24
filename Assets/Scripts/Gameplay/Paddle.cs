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
    /// Detects collision with a ball to aim the ball
    ///
    /// 
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
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
