using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages Block game object behavior
/// </summary>
public class Block : MonoBehaviour
{
    // Sprite for half-life state
    [SerializeField]
    Sprite brokenBlock;

    // Health support
    int maxHealth;

    [SerializeField]
    int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    /// <summary>
    /// Handles collisions
    /// Specifically will handle getting hit by the ball
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the game object we collided w/ has a tag "Ball"
        if (collision.gameObject.tag == "Ball")
        {
            // We've been hit
            print("We've been hit!");

            // Reduce the block's health
            health -= collision.gameObject.GetComponent<Ball>().Damage;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
            // If we're at the mid-way point in health (or over)
            else if (maxHealth / health >= 2)
            {
                // Render broken block instead 
                GetComponent<SpriteRenderer>().sprite = brokenBlock;
            }
        }
    }
}
