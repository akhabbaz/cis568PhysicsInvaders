﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
   
    public Vector3 forceVector;
    public Bullet  bullet;
    float timeLastShot;
    float minTimeDiff;
    public GameObject deathExplosion;
    public AudioClip deathKnell;
    private Global gameController;
    // Use this for initialization
    void Start() {
        forceVector.x = 10.0f;
        timeLastShot = 0.0f;
        minTimeDiff = 0.5f;
        print(" This is a test");
        GameObject g = GameObject.Find("GlobalObject");
        gameController = g.GetComponent<Global>();
    }
    void Update()
    {// the Collision contains a lot of info, but it’s the colliding
        // object we’re most interested in. Collider collider = collision.collider;
        if (Input.GetButtonDown("Fire1"))
        {
            /* we don’t want to spawn a Bullet inside our ship, so some
            Simple trigonometry is done here to spawn the bullet at the tip of where the ship is pointed.
            */
            float currentTime = Time.time;
            if (currentTime > minTimeDiff + timeLastShot)
            {
                timeLastShot = currentTime;
                Vector3 spawnPos = gameObject.transform.position;
                spawnPos.y += 0.75f;
                 LaunchBullet(spawnPos);
                // get the Bullet Script Component of the new Bullet instance
                //Bullet b = obj.GetComponent<Bullet>();
                // set the direction the Bullet will travel in
               
            }
        }
    }

    private Bullet LaunchBullet(Vector3 spawnPos)
    {
        // instantiate the Bullet
        Bullet b = Instantiate(bullet, spawnPos, Quaternion.identity);// as GameObject;
        Quaternion rot = Quaternion.Euler(new Vector3(0, 180, 0));
        b.heading = rot;// Bullet bp = b.GetComponent<Bullet>();
        b.AddForce(new Vector3(0, 240.0f, 0));
        return b;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            // force thruster
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                GetComponent<Rigidbody>().AddRelativeForce(forceVector);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                GetComponent<Rigidbody>().AddRelativeForce(-forceVector);
            }

    }
    void OnCollisionEnter(Collision collision)
    {
        // the Collision contains a lot of info, but it’s the colliding
        // object we’re most interested in. Collider collider = collision.collider;

        Collider collider = collision.collider;
        if (collider.CompareTag("Bullet"))
        {
            Die();
        }
    }
    
    public void Die()
    {
        // Destroy removes the gameObject from the scene and
	// plays a nice explosion
        AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
        Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
        // marks it for garbage collection
        Destroy(gameObject);
        gameController.PlayerDead();
    }
}

