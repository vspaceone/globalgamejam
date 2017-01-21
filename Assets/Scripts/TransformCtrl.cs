using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformCtrl : MonoBehaviour {

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

	void FixedUpdate() {

	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("Transformer triggered");

		if (col.gameObject.name.Equals ("Projektil(Clone)")) {
			ProjektilCtrl projektil = col.gameObject.GetComponent<ProjektilCtrl> ();
			projektil.toggleType ();

		}
	}
}
