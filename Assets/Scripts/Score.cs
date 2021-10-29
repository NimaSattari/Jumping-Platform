using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    Text scoreText;
    Text HighestScore;
    public static int highscore;
    int score;

    private void Awake()
    {
        HighestScore = GameObject.Find("HighestScore").GetComponent<Text>();
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        HighestScore.text = highscore.ToString();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        MakeInstance();
    }

    private void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    void Update()
    {
        if (score > highscore)
        {
            highscore = score;
            HighestScore.text = "" + score;

            PlayerPrefs.SetInt("highscore", highscore);
        }
    }
    public int GetScore()
    {
        return score;
    }
}
