using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Fields
    private static GameManager gameManager;

    private int points;
    private int ballsLeft;
    private bool gameOver;

    #endregion

    #region Properties

    public bool GameOver 
    {
        get { return gameOver; }
    }

    public int BallsLeft
    {
        get { return ballsLeft; }
    }

    public int Points 
    {
        get { return points; }
    }

    public static GameManager instance
    {
        get
        {
            if (!gameManager)
            {
                gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (!gameManager)
                {
                    Debug.LogError("There needs to be one active GameManager script on a GameObject in your scene.");
                }
                else
                {
                    gameManager.Init();

                    //  Sets this to not be destroyed when reloading scene
                    DontDestroyOnLoad(gameManager);
                }
            }
            return gameManager;
        }
    }

    #endregion

    #region Methods

    void Init()
    {
        points = 0;
        ballsLeft = 3;
        gameOver = false;

        EventManager.StartListening(EventName.AddPoints, UpdatePoints);
        EventManager.StartListening(EventName.LoseBall, LostBall);
    }

    private void LostBall(Dictionary<string, object> msg)
    {
        if (ballsLeft > 0)
        {
            ballsLeft--;
            HUD.UpdateBallsLeftText();
        }
        else
        {
            gameOver = true;
            EventManager.TriggerEvent(EventName.GameOver, null);
        }

    }

    private void UpdatePoints(Dictionary<string, object> msg)
    {
        points += Convert.ToInt32(msg["points"]);
        HUD.UpdateScoreText();
    }

    #endregion
}
