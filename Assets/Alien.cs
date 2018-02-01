using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Alien : MonoBehaviour, IComparable<Alien> {
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
    public int CompareTo(Alien other)
    {
	    if (other == null) {
		    return 1;
	    }
	    return 0;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
