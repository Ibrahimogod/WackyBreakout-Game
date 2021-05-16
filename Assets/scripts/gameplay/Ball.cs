using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
    //support move
    Rigidbody2D rb2d;

    // move delay timer
    Timer moveTimer;

    // death timer
    Timer deathTimer;

    // speed effec support
    Timer speedTimer;
    bool speeded = false;

    //monitor ball
    float timeLeft;
    public static float TimeLeft { get; set; }

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
        // start move timer
        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1;
        moveTimer.Run();

        // start death timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeSeconds;
        deathTimer.Run();

        //support move 
        rb2d = GetComponent<Rigidbody2D>();
        //add speed timer
        speedTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedListener(SpeedUp);


    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
	{
        // move when time is up
        if (moveTimer.Finished)
        {
            moveTimer.Stop();
            StartMoving();
        }

        // die when time is up
        if (deathTimer.Finished)
        {
            // spawn new ball and destroy self
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }

        if (speedTimer.Finished)
        {
            speedTimer.Stop();
            speeded = false;
            Camera.main.GetComponent<SpeedupEffectMonitor>().SpeedUpActivated = false;
            rb2d.velocity /= 3;
        }

        if (speeded)
            TimeLeft = speedTimer.TimeLeft;
	}

    /// <summary>
    /// Spawn new ball and destroy self when out of game
    /// </summary>
    void OnBecameInvisible()
    {
        // death timer destruction is in Update
        if (!deathTimer.Finished)
        {
            // only spawn a new ball if below screen
            float halfColliderHeight = 
                gameObject.GetComponent<BoxCollider2D>().size.y / 2;
            if (transform.position.y - halfColliderHeight < ScreenUtils.ScreenBottom)
            {
                Camera.main.GetComponent<BallSpawner>().SpawnBall();
                HUD.ReduceBallsLeft();
            }
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Starts the ball moving
    /// </summary>
    void StartMoving()
    {
        // get the ball moving
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        if (EffectUtils.SpeedActivated)
        {
            speeded = true;
            speedTimer.Duration = EffectUtils.TimeLeft;
            speedTimer.Run();
            force *= 3;
        }
        rb2d.AddForce(force);
    }

    /// <summary>
    /// Sets the ball direction to the given direction
    /// </summary>
    /// <param name="direction">direction</param>
    public void SetDirection(Vector2 direction)
    {
        // get current rigidbody speed
        
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }

    void SpeedUp(float duration)
    {
        if (!speeded)
        {
            speedTimer.Duration = duration;
            speedTimer.Run();
            speeded = true;
            Camera.main.GetComponent<SpeedupEffectMonitor>().SpeedUpActivated = true;
            rb2d.velocity *= 3;
        }
        else
            speedTimer.Duration = duration;
    }
}