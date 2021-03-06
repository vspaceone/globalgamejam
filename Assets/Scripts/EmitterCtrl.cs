﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterCtrl : MonoBehaviour {

	public GameObject projektilPrefab;
	public Transform spawnPoint;
	public float reloadTime = 4;
	public float shootpower = 500;
	public AudioClip emitSound;

	private Rigidbody2D rb;
	private Animator animator;
	private GameObject projektil;
	private AudioSource audio;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey("space") && projektil == null ) {
			projektil = (GameObject)Instantiate (projektilPrefab, spawnPoint.position, Quaternion.identity);
			float radian = ((rb.transform.eulerAngles.z - 90) / 180) * Mathf.PI;
			Vector2 direction = new Vector2 (Mathf.Cos(radian), Mathf.Sin(radian));
			projektil.GetComponent<Rigidbody2D> ().AddForce (direction * shootpower);
			AudioSource.PlayClipAtPoint(emitSound, new Vector3(0, 0, 0));
		}

	}

	void FixedUpdate(){

	}

}
