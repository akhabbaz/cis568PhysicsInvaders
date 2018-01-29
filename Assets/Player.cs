﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
   
    public Vector3 forceVector;
    public GameObject bullet;
    float timeLastShot;
    float minTimeDiff;
    // Use this for initialization
    void Start () {
        forceVector.x = 1.0f;
        timeLastShot = 0.0f;
        minTimeDiff = 0.5f;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire! ");
            /* we don’t want to spawn a Bullet inside our ship, so some
            Simple trigonometry is done here to spawn the bullet at the tip of where the ship is pointed.
            */
            float currentTime = Time.time;
            if (currentTime > minTimeDiff + timeLastShot)
            {
                timeLastShot = currentTime;
                Vector3 spawnPos = gameObject.transform.position;
                spawnPos.y += 0.75f;
                // instantiate the Bullet
                GameObject obj = Instantiate(bullet, spawnPos, Quaternion.identity) as GameObject;
                // get the Bullet Script Component of the new Bullet instance
                Bullet b = obj.GetComponent<Bullet>();
                // set the direction the Bullet will travel in
                Quaternion rot = Quaternion.Euler(new Vector3(0, 0, 0));
                b.heading = rot;
            }
        }
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
}
