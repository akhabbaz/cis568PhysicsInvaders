using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Alien : MonoBehaviour, IComparable<Alien> {
    // Use this for initialization
    public GameObject deathExplosion;
    private AlienManager alienManager;
    public AudioClip deathKnell;
    private int hor;
    private int vert;
    public void Start()
    {
        hor = 0;
        vert = 0;
    }
    // relative location of this alien
    public void Location(int h, int v) {
        hor =  h;
        vert = v;
    }
    public void UpdateManager(AlienManager manager)
    {
        if (alienManager == null && manager != null)
        {
            alienManager = manager;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // the Collision contains a lot of info, but it’s the colliding
        // object we’re most interested in. Collider collider = collision.collider;
        Collider collider = collision.collider;
        if (collider.CompareTag("Alien"))
        {
            Alien otheralien = collider.gameObject.GetComponent<Alien>();
            otheralien.Die();
        }


        // Die();
    }
    public void Die()
    {
        // Destroy removes the gameObject from the scene and
        AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
        Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(0, Vector3.forward));
        // marks it for garbage collection
        //Alien thisA = gameObject.GetComponent<Alien>();
        int countinit = alienManager.AliensLeft(); 
        alienManager.RemoveAlien(this);
        if (countinit != alienManager.AliensLeft() + 1)
        {
            Debug.Log("Alien not removed from list");
        }
        Destroy(gameObject);
    }
    public int CompareTo(Alien other)
    {
        if (other == null) { 
            return -1;
        }
        if (hor < other.hor){
           return -1;
        }
        else if ( hor > other.hor)
        {
            return 1;
        }
        else if (vert  < other.vert){
            return -1;
        }
        else if (vert > other.vert)
        {
            return 1;
        }
        // hor and vert both equal
	    return 0;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
