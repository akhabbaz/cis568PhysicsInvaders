using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScript : MonoBehaviour {
    private double starttime;
    private const double TimeInterval = 5.0;
	// Use this for initialization
	void Start () {
        starttime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	     if (Time.time > starttime + TimeInterval)
        {
            Die();
        }
	}
    public void Die()
    {
	    Destroy(gameObject);
    }
}
