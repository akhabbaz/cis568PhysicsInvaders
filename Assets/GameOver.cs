using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    private float timer;

	// Use this for initialization
	void Start () {
        timer = 0;	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            SceneManager.LoadScene("TitleScene");
        }

		
	}
}
