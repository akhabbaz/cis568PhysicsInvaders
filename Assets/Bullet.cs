using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public Quaternion heading;
	// store the camera so that one can 
	// kill bullets off of the screen.
        // Use this for initialization
        void Start()
        {
            // do not passively decelerate
            GetComponent<Rigidbody>().drag = 0;
        // set the direction it will travel in
        // Use this for initialization
        // apply thrust once, no need to apply it again since
        // it will not decelerate
        heading = Quaternion.Euler(new Vector3(0, 90, 0)); 
            GetComponent<Rigidbody>().MoveRotation(heading);
        transform.Rotate(new Vector3(0, 0, 90));
         }
    // Update is called once per frame
    public void AddForce(Vector3 thrust)
    {
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
    }
    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        if (collider.CompareTag("Alien"))
        {
            Alien hitAlien =
            collider.gameObject.GetComponent<Alien>(); // let the other object handle its own death throes
            hitAlien.Die(); // Destroy the Bullet which collided with the Asteroid
        }
        else
        { // if we collided with something else, print to console
          // what the other thing was
            Debug.Log("Collided with " + collider.tag);
        }

        Die();
        
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
