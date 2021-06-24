using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles Ball behavior
/// </summary>
public class Ball : MonoBehaviour
{
    #region Fields
    private Rigidbody2D body;
    private Timer deathTimer;
    private Timer startTimer;

    [SerializeField]
    float startingAngle = 20f;
    Vector2 normalForce;

    [SerializeField]
    int damage = 50;

    #endregion

    #region Properties

    public int Damage
    {
        get { return damage; }
    }

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        normalForce = new Vector2(ConfigurationUtils.BallImpulseForce * Mathf.Cos(startingAngle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(startingAngle));

        EventManager.StartListening(EventName.GameOver, StopMoving);
        EventManager.StartListening(EventName.SpeedupEffectActivated, MoveFast);
        EventManager.StartListening(EventName.SpeedupEffectEnded, MoveNormal);

        // Get timer component
        deathTimer = gameObject.AddComponent<Timer>();
        startTimer = gameObject.AddComponent<Timer>();

        // Set duration to ball life time & run
        deathTimer.Duration = ConfigurationUtils.BallDeathTime;
        deathTimer.Run();

        startTimer.Duration = 1;
        startTimer.Run();
    }

    void Update()
    {
        if (startTimer.Finished)
        {
            startTimer.Stop();
            GetMoving();
        }
        // If Ball has reached the end of it's lifetime, destroy it
        if (deathTimer.Finished)
        {
            DestroyBall();
        }
    }

    /// <summary>
    /// Stops ball movement
    /// </summary>
    /// <param name="msg">null</param>
    private void StopMoving(Dictionary<string, object> msg)
    {
        body.velocity = Vector3.zero;
    }

    /// <summary>
    /// Sets velocity to original
    /// </summary>
    /// <param name="msg">null</param>
    private void MoveNormal(Dictionary<string, object> msg)
    {
        body.velocity = normalForce;
    }

    /// <summary>
    /// Sets velocity to itself times speedup multiplier
    /// </summary>
    /// <param name="msg">null</param>
    private void MoveFast(Dictionary<string, object> msg)
    {
        Vector2 vel = body.velocity.normalized;

        body.velocity = vel * EffectUtils.SpeedupFactor;
    }

    /// <summary>
    /// Adds force to the ball
    /// </summary>
    private void GetMoving()
    {
        body.AddForce(normalForce, ForceMode2D.Force);

        // If the speedup effect is active, have the ball start fast
        if (EffectUtils.SpeedupActive)
        {
            MoveFast(null);
        }
    }

    /// <summary>
    /// Sets ball velocity and direction
    /// </summary>
    /// <param name="direction">Vector for direction</param>
    public void SetDirection(Vector2 direction)
    {
        // Set the velocity to the current speed (magnitude) times the new direction
        body.velocity = body.velocity.magnitude * direction;
    }

    /// <summary>
    /// If the ball leaves the screen, destroy it
    /// </summary>
    private void OnBecameInvisible()
    {
        if (transform.position.y <= ScreenUtils.ScreenBottom) {
            // Destroy ball when it leaves the screen view
            DestroyBall();
        }
    }

    /// <summary>
    /// Destroys the ball - used in various situations
    /// Spawns new ball before "death"
    /// </summary>
    private void DestroyBall()
    {
        // Trigger lost ball event
        EventManager.TriggerEvent(EventName.LoseBall, null);

        // Stop listening for Game Over event
        EventManager.StopListening(EventName.GameOver, StopMoving);
        EventManager.StopListening(EventName.SpeedupEffectActivated, MoveFast);

        if (!GameManager.instance.GameOver)
        {
            // Spawn a new ball before death
            Camera.main.GetComponent<BallSpawner>().SpawnBallWithChecks();
        }

        // Destroy this game object
        Destroy(gameObject);
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

    #endregion

}
