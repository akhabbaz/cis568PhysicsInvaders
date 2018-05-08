using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour {
    public AlienManager alienManager;
    public Player player;
    public float timer;
    public float spawnPeriod;
    public int numberSpawnedEachPeriod;
    public Vector3 originInScreenCoordinates;
    public int score;
    private AlienManager currentWave;
    public int LivesLeft;
    private float pauseTime = 2.0f;
    private bool waitToCreate;
    // Use this for initialization
    void Start() {
        score = 0;
        timer = 0;
        spawnPeriod = 5.0f;
        numberSpawnedEachPeriod = 3;
        LivesLeft = 5;
        waitToCreate = false;
        currentWave = Instantiate(alienManager, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        LivesLeft--;
    }
    public void PlayerDead()
    {
        if (LivesLeft > 0)
        {
            LivesLeft--;
            waitToCreate = true;
            timer = 0.0f;
        }
    }
    private void CreateNewPlayer()
    {
            Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
            waitToCreate = false;
    }
    public void AlienDead()
    {
        score += 5;
    }
    public void CurrentWaveOver()
    {
        score += 10;
        float nextRate = currentWave.fireRate * 0.8f;
        int nextx = Math.Min(10, currentWave.numberx + 2);
        currentWave = Instantiate(alienManager, new Vector3(0, 0, 0), Quaternion.identity);
        currentWave.fireRate = nextRate;
        currentWave.numberx = nextx;
        Debug.Log(score);
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (LivesLeft <= 0)
        {
            PlayerPrefs.SetInt("CurrentScore", score);
            int highScore = PlayerPrefs.GetInt("HighScore");
            if (score > highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            StaticClassState.gameState = StaticClassState.GameState.GameOver;
            StaticClassState.CurrentScore = score;
            SceneManager.LoadScene("GameOver");

        }
        else if (waitToCreate && timer > pauseTime)
        {
            CreateNewPlayer();
        }
        
		
	}
}
