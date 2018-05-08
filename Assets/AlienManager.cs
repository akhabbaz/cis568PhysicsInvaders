using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour {
    private Global gameController;
	float xStart = -5;
    float xstep = 2.5f;
	public int numberx = 4;
    float yStart = 2.0f;
    float ystep = 2.5f;
    float numbery = 2.0f;
    float stepPerUpdate = 0.05f;
    float minX = 0.0f;
    float maxX = 0.0f;
    // rate at which aliens fire on average
    public float fireRate = 5.0f;
    public Alien prefabAlien;
    List<Alien> aliens;
    // Use this for initialization
    AlienManager()
        { }
    void Start() {
        aliens = new List<Alien>();
        GameObject g = GameObject.Find("GlobalObject");
        gameController = g.GetComponent<Global>();
        Debug.Log("Spawn Period " + gameController.spawnPeriod);
        xStart = -numberx * 1.25f + 2.5f;
        for (int i = numberx - 1; i >= 0; --i) {
            for (int j = 0; j < numbery; ++j)
            {
                Vector3 test = new Vector3(xStart + i * xstep,
                    yStart + j * ystep, 0);
                if (xStart + i * xstep < minX)
                {
                    minX = xStart + i * xstep;
                }
                if ((xStart + i * xstep) > maxX)
                {
                    maxX = xStart + i * xstep;
                }
                Alien oneAlien = Instantiate(prefabAlien, test, Quaternion.identity);
                oneAlien.Location(i, j);
                oneAlien.UpdateManager(gameObject.GetComponent<AlienManager>());
                oneAlien.name = " " + i + " " + j;
                aliens.Add(oneAlien);
            }
        }
        aliens.Sort();
        minX -= 5.0f;
        maxX += 5.0f;

	}
    public int AliensLeft()
    {
        return aliens.Count;
    }
    // Each Alien calls this to determine if it is the firing Alien
    public void FireAliens()
    { 
       int lasthor = -1;
        for (int i = 0; i < aliens.Count; ++i)
        {
            Alien u = aliens[i];
            if (aliens[i].load)
            {
                lasthor = aliens[i].Horizontal();
            }
            // new horizontal that has no bullet loaded
            else if ( aliens[i].Horizontal() != lasthor){
	   	        aliens[i].LoadFire();
		        lasthor = aliens[i].Horizontal();
	       }
       	  
       }
    }
    public void Die()
    {
        gameController.CurrentWaveOver();
        Destroy(gameObject);

    }
    public void RemoveAlien(Alien deadAlien)
    {
        int index = aliens.BinarySearch(deadAlien);
        if (index >= 0)
        {
            aliens.RemoveAt(index);
            gameController.AlienDead();
            if (AliensLeft() == 0)
            {
                Die();
            }
        }
        else
        {
            Debug.Log("repeated call to remove");
        }

    }
	// Update is called once per frame:
	void Update () {
            float pos = aliens[0].transform.position[0];

            if (pos < minX)
            {
                stepPerUpdate *= -1;
            }
            int last = aliens.Count - 1;
            pos = aliens[last].transform.position[0];
            if (pos > maxX)
            {
                stepPerUpdate *= -1;
            }
            foreach (Alien al in aliens)
            {
                pos = al.transform.position.x;
                al.transform.Translate(stepPerUpdate, 0, 0);
            }
            FireAliens();

     
    }
}
