using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCtrl : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator animator;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		//Check collision name
		Debug.Log("collision name = " + col.gameObject.name);
		if (col.gameObject.name.Equals("Projektil(Clone)")) {
			Debug.Log ("Win!");
			Destroy (col.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
				
	}

	void FixedUpdate(){

	}

}
