using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrentScoreScript : MonoBehaviour {
    public Text currentScoreText;
    public Text CurrentMode;
    public Text highScoreText;
    private int highScore;
	// Use this for initialization
	void Start () {
        // update the static CurrentScore or the PlayerPrefs CurrentScore
        if (StaticClassState.gameState == StaticClassState.GameState.HighScore)
        {
            StaticClassState.CurrentScore = PlayerPrefs.GetInt("CurrentScore");
        }
        else if (StaticClassState.gameState == StaticClassState.GameState.GameOver)
        {
            PlayerPrefs.SetInt("CurrentScore", StaticClassState.CurrentScore);
        }
        highScore = PlayerPrefs.GetInt("HighScore");
        if (StaticClassState.CurrentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", StaticClassState.CurrentScore);
        }
	}

	// Update is called once per frame
	void Update () {
        string currentText;
        if (StaticClassState.gameState == StaticClassState.GameState.HighScore)
        {
            CurrentMode.text = "Space Invaders";
            currentText = "Last Score: ";
        }
        else
        {
            CurrentMode.text = "Game Over!!";
            currentText = "Your Score: ";
        }
        currentScoreText.text = currentText + StaticClassState.CurrentScore;
        highScoreText.text = "High Score: " + highScore;
	}
}
