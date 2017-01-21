using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementCtrl : MonoBehaviour {
	private Rigidbody2D rb; 
	//private BoxCollider2D box;
	Transform box;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("n");
		rb = GetComponent<Rigidbody2D> ();
		box = GetComponent<Transform> ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log ("Muh");
	}

	void OnMouseDrag() {
		Vector2 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 vec = new Vector2 (mouse.x - rb.transform.position.x, mouse.y - rb.transform.position.y);
		float rot = Vector2.Angle (vec, new Vector2 (1, 0));
		Debug.Log("Pos " + Input.mousePosition + " " + vec + " " + rot);
		box.rotation = Quaternion.Euler(0, 0, rot);
	}

}
