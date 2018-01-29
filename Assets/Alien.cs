using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void Die()
    {
        // Destroy removes the gameObject from the scene and
        // marks it for garbage collection
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
