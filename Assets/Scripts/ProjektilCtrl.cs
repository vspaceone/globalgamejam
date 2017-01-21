using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjektilCtrl : MonoBehaviour {

	public float speed = 200;

	Rigidbody2D rb;
	Animator animator;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		Vector3 startImpuls = new Vector3 (speed, 0, 0);

		rb.AddForce (startImpuls);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){


		
	}
}
