﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCtrl : MonoBehaviour {

	public AudioClip absorbSound;

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

		if (col.gameObject.name.Equals("Projektil(Clone)")) {
			ProjektilCtrl pro = col.gameObject.GetComponent<ProjektilCtrl> ();
			Destroy(col.gameObject);
			AudioSource.PlayClipAtPoint (absorbSound, new Vector3 (0, 0, 0));

		}
	}
}
