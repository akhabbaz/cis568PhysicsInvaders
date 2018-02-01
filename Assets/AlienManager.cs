using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour {
	float xStart = -1;
	float xstep =  1f;
	int number = 2;
    public GameObject oneAlien;
    List<GameObject> aliens;
    // Use this for initialization
    void Start () {
		List<GameObject> aliens = new List<GameObject>();

		for (float i = 0; i < number; ++i) {
            Vector3 test = new Vector3(xStart + i * xstep, 2.0f);
            GameObject alien = Instantiate(oneAlien, test, Quaternion.identity) as GameObject;
			aliens.Add(oneAlien);
		}
		aliens.Sort();
		foreach(GameObject al in aliens)
		{
			print (al.name);
		}
        aliens.Clear();
		
	}
	
	// Update is called once per frame:
	void Update () {
        foreach (GameObject al in aliens)
        {
            print(al.name);
        }
        aliens.Clear();
    }
}
