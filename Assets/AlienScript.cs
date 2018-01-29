using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    void OnCollisionEnter(Collision collision)
    {
        // the Collision contains a lot of info, but it’s the colliding
        // object we’re most interested in. Collider collider = collision.collider;
        if (collider.CompareTag("Asteroids"))
        {
            Asteroid roid =
            collider.gameObject.GetComponent<Asteroid>(); // let the other object handle its own death throes
            roid.Die(); // Destroy the Bullet which collided with the Asteroid
            Destroy(gameObject);
        }
        else
        { // if we collided with something else, print to console
          // what the other thing was
            Debug.Log("Collided with " + collider.tag);
        }
        14
}
    // Update is called once per frame
    void Update () {
		
	}
}
