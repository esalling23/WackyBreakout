using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages Block game object behavior
/// </summary>
public class Block : MonoBehaviour
{
    #region Fields
    // Points support
    protected int points = 50;

    // Sprite for half-life state
    protected Sprite brokenBlock;

    // Health support
    int maxHealth;

    [SerializeField]
    protected int health = 100;

    #endregion

    #region Methods

    // Start is called before the first frame update
    protected void Start()
    {
        maxHealth = health;
    }

    /// <summary>
    /// Handles collisions
    /// Specifically will handle getting hit by the ball
    /// </summary>
    /// <param name="collision"></param>
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        // If the game object we collided w/ has a tag "Ball"
        if (collision.gameObject.tag == "Ball")
        {
            // Reduce the block's health
            health -= collision.gameObject.GetComponent<Ball>().Damage;

            if (health <= 0)
            {
                EventManager.TriggerEvent(EventName.AddPoints, new Dictionary<string, object> { { "points", points } });
                Destroy(gameObject);
            }
            // If we're at the mid-way point in health (or over)
            else if (maxHealth / health >= 2 && brokenBlock != null)
            {
                // Render broken block instead 
                GetComponent<SpriteRenderer>().sprite = brokenBlock;
            }
        }
    }

    #endregion
}
