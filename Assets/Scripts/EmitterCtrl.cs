﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		Debug.Log ("n");
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log ("Muh");
	}

}
