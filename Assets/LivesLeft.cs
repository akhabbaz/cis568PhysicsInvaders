using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LivesLeft : MonoBehaviour {
    Global globalObj;
    public Text lifeText;
	// Use this for initialization
	void Start () {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
		
	}
	
	// Update is called once per frame
	void Update () {
        lifeText.text = "Lives Left: " + globalObj.LivesLeft.ToString();	
	}
}
