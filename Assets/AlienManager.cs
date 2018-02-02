using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour {
	float xStart = -1;
	float xstep =  5f;
	int number = 2;
    public Alien prefabAlien;
    List<Alien> aliens;
    // Use this for initialization
    AlienManager()
        { }
     void Start() { 
		List<Alien> aliens = new List<Alien>();

		for (float i = 0; i < number; ++i) {
            Vector3 test = new Vector3(xStart + i * xstep, 2.0f);
            Alien oneAlien =  Instantiate(prefabAlien, test, Quaternion.identity);
            oneAlien.name = "  1";
            aliens.Add(oneAlien);
		}
		aliens.Sort();
	}
	
    void removeAlien(Alien deadAlien)
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
