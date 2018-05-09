using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Alien : MonoBehaviour, IComparable<Alien> {
    // Use this for initialization
    public GameObject deathExplosion;
    // get game controller to add points when alien falls
    private Global gameController;
    private AlienManager alienManager;
    public AudioClip deathKnell;
    public Bullet bullet;
    private int hor;
    private int vert;
    double triggerTime;
    // fire randomly
    public bool load;
    // fallen tells if the alien has just fallen down
    private bool fallen;
    void Start()
    {
        load = false;
        triggerTime = Time.time + 1000;
        fallen = false;
        GameObject g = GameObject.Find("GlobalObject");
        gameController = g.GetComponent<Global>();
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
            otheralien.AlienHit();
        }
        AlienHit();
    }

    public int Horizontal() 
    {
    	return hor;
    }
    public int Vertical()
    {
        return vert;
    }
    private Bullet LaunchBullet(Vector3 spawnPos)
    {
        // instantiate the Bullet
        Bullet b = Instantiate(bullet, spawnPos, Quaternion.identity);// as GameObject;
                                                                      // Bullet bp = b.GetComponent<Bullet>();
        Quaternion rot = Quaternion.Euler(new Vector3(0, 90, 0));

        b.heading = rot;
        Vector3 thrust = new Vector3(0, -120, 0);
        b.AddForce(thrust);
        return b;
    }
    public void AlienHit()
    {
        if (!fallen)
        {
            AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
            // marks it for garbage collection
            //Alien thisA = gameObject.GetComponent<Alien>();
            Collider collider = GetComponent<Collider>();
            collider.attachedRigidbody.useGravity = true;
            int countinit = alienManager.AliensLeft();
            alienManager.RemoveAlien(this);
            if (countinit != alienManager.AliensLeft() + 1)
            {
                Debug.Log("Alien not removed from list");
            }
            fallen = true;
        }
    }
    public void Die()
    {
        gameController.score += 3;
        Destroy(gameObject);
    }
    public void LoadFire() {
        load = true;
        triggerTime = Time.time + UnityEngine.Random.value * alienManager.fireRate;
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
    public void Fire() {
        if (load && triggerTime < Time.time)
        {
            load = false;
            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.y -= 0.75f;
            LaunchBullet(spawnPos);
        }
	}
    void Update()
    {
        Fire();
        Vector3 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
	    if (screenPos.y > Screen.height || screenPos.y < 0) {
		    Die();
	    }
    }
}
