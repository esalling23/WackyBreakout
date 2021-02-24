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
    float halfWidth;

    // Start is called before the first frame update
    void Start()
    {

        body = GetComponent<Rigidbody2D>();

        // Gets the width of the box collider component
        halfWidth = GetComponent<BoxCollider2D>().size.x / 2;
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
        if (newXPosition <= ScreenUtils.ScreenLeft + halfWidth)
        {
            return ScreenUtils.ScreenLeft + halfWidth;
        }
        else if (newXPosition >= ScreenUtils.ScreenRight - halfWidth)
        {
            return ScreenUtils.ScreenRight - halfWidth;
        }

        return newXPosition;
    }
}
