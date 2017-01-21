using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateable : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator animator;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 mousePosition = Input.mousePosition;
		Vector2 mouse2d = new Vector2 (mousePosition.x, mousePosition.y);


	}
}
