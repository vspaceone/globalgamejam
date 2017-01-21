using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjektilCtrl : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator animator;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if (Input.GetKey ("space")) {
			toggleType ();
		}
		
	}

	void toggleType(){
	//	type = !type;
	}
}
