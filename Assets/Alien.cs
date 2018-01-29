using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {
    // Use this for initialization
    public GameObject deathExplosion;
    public AudioClip deathKnell;
    void Start () {
		
    }
    void OnCollisionEnter(Collision collision)
    {
        // the Collision contains a lot of info, but it’s the colliding
        // object we’re most interested in. Collider collider = collision.collider;
       Die(); 
    }
    public void Die()
    {
        // Destroy removes the gameObject from the scene and
        AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
        Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(0, Vector3.forward));
        // marks it for garbage collection
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
