using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages Paddle game object behavior
/// </summary>
public class Paddle : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector3 position;
    private float horizontalInput;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0) 
        {
            position = transform.position;
            position.x += horizontalInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.fixedDeltaTime;
            body.MovePosition((Vector2)position);
        }
    }
}
