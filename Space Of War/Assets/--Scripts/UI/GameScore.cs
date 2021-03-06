﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    // refrence variables
    public Text scoreTextUI;
    public Text highScoreText;
    public InputField highScoreInput;
    // varaibles
    int score;
    int highScore;
    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // Get the Text UI component of this gameObject
        scoreTextUI = GetComponent<Text>();
        
    }
    // Function to update the score text UI
    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:0000}",score);
        scoreTextUI.text = scoreStr;
        // getting high score and storing it in player prefs
        highScore = score;
        scoreTextUI.text = highScore.ToString();

        if (PlayerPrefs.GetInt("score") <= highScore)
        {
            PlayerPrefs.SetInt("score", highScore);
            highScoreInput.gameObject.SetActive(true);
        }

        
        highscorefun();
    }

    public void highscorefun()
    {
        highScoreText.text = PlayerPrefs.GetInt("score").ToString();
    }
    public void NewHighName()
    {
        string highScoreName = highScoreInput.text;
        PlayerPrefs.SetString("HIGHSCORENAME", highScoreName);
        highScoreInput.gameObject.SetActive(false);
        highScoreText.text = "Congratulations " + highScoreName + "\n" + "New High Score is " + score;
    }
}
