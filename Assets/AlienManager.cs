using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour {
	float xStart = -5;
    float xstep = 2.5f;
	int numberx = 8;
    float yStart = 2.0f;
    float ystep = 2.5f;
    float numbery = 2.0f;
    public Alien prefabAlien;
    List<Alien> aliens;
    // Use this for initialization
    AlienManager()
        { }
     void Start() { 
		List<Alien> aliens = new List<Alien>();

		for (float i = 0; i < numberx; ++i) {
            for (float j = 0; j < numbery; ++j)
            {
                Vector3 test = new Vector3(xStart + i * xstep, 
                    yStart + j * ystep, 0);
                Alien oneAlien = Instantiate(prefabAlien, test, Quaternion.identity);
                oneAlien.name = "  1";
                aliens.Add(oneAlien);
            }
		}
		aliens.Sort();
	}
	
    public void RemoveAlien(Alien deadAlien)
    {
        int index = aliens.BinarySearch(deadAlien);
        aliens.RemoveAt(index);
    }
	// Update is called once per frame:
	void Update () {
        foreach (Alien al in aliens)
        {
            print(al.name);
        }
     
    }
}
