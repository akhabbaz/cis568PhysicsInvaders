﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public Vector3 thrust;
	public Quaternion heading;
	// store the camera so that one can 
	// kill bullets off of the screen.
        // Use this for initialization
        void Start()
        {
            // travel straight in the X-axis
            thrust.y =120.0f;
            // do not passively decelerate
            GetComponent<Rigidbody>().drag = 0;
            // set the direction it will travel in
            GetComponent<Rigidbody>().MoveRotation(heading);
            // Use this for initialization
            // apply thrust once, no need to apply it again since
            // it will not decelerate
            GetComponent<Rigidbody>().AddRelativeForce(thrust);
         }
    // Update is called once per frame
    void Update()
    { //Physics engine handles movement, empty for now. }
        Vector3 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
	if (screenPos.y > Screen.height || screenPos.y < 0) {
		Die();
	}
    }
    public void Die()
    {
	    Destroy(gameObject);
    }

}