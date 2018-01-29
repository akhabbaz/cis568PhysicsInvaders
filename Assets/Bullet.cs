using System.Collections;
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
    
    void OnCollisionEnter(Collision collision)
    {
        // the Collision contains a lot of info, but it’s the colliding
        // object we’re most interested in. Collider collider = collision.collider;
        Collider collider = collision.collider;
        if (collider.CompareTag("Alien"))
        {
            Alien alien =
            collider.gameObject.GetComponent<Alien>(); // let the other object handle its own death throes
            alien.Die();
            // Destroy the Bullet which collided with the Asteroid
            Die();
        }
        else if (collider.CompareTag("Player"))
        {
            Player player = collider.gameObject.GetComponent<Player>();
            player.Die();
            // Destroy the bullet which collided with the Asteroid
            Die();

        }
        else
        { // if we collided with something else, print to console
          // what the other thing was
            Debug.Log("Collided with " + collider.tag);
        }
    }
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
