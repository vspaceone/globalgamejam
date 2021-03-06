﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyBorder : MonoBehaviour {

	public AudioClip destroySound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		//Check collision name
		Debug.Log("collision name = " + col.gameObject.name);
		AudioSource.PlayClipAtPoint (destroySound, new Vector3 (0, 0, 0));
	  	Destroy(col.gameObject);
	}
}
