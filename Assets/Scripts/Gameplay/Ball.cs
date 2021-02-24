using System.Collections;
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

    /// <summary>
    /// Adds direction to bounces off the paddle, walls
    ///
    /// Original from https://answers.unity.com/questions/1687930/how-to-change-bouncing-direction.html
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        print("collided");

        if (Mathf.Abs(body.velocity.x) <= 0.1 || Mathf.Abs(body.velocity.y) <= 0.1)
        {
            print(body.velocity);
            float angle = Random.Range(0, 20f);
            body.AddForce(new Vector2(ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle)), ForceMode2D.Force);
        }
    }
}
