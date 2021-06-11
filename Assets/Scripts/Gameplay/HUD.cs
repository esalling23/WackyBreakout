using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    static GameObject gameOverScreen;
    static Text scoreText; 
    static Text ballsLeftText;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening(EventName.GameOver, DisplayGameOverScreen);
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        UpdateScoreText();

        ballsLeftText = GameObject.FindGameObjectWithTag("BallsLeftText").GetComponent<Text>();
        UpdateBallsLeftText();

        gameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen");
        gameOverScreen.SetActive(false);
    }

    private void DisplayGameOverScreen(Dictionary<string, object> msg)
    {
        gameOverScreen.SetActive(true);
    }

    public static void UpdateScoreText()
    {
        scoreText.text = "Score: " + GameManager.instance.Points;
    }

    public static void UpdateBallsLeftText()
    {
        ballsLeftText.text = "Balls Left: " + GameManager.instance.BallsLeft;
    }
}
