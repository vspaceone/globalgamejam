﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementCtrl : MonoBehaviour {
	public enum ElementType
	{
		Glass,
		Mirror,
		Wall,
		Grid,
		Water,
	}
	private Rigidbody2D rb;
	private float relRot;

	public ElementType type;
	public Sprite glassSprite;
	public Sprite mirrorSprite;
	public Sprite wallSprite;
	public Sprite gridSprite;
	public Sprite waterSprite;
	public AudioClip bounceSound;
	public BoxCollider2D collid;



	//private BoxCollider2D box;
	Transform box;

	public ElementType Type {
		get { return type; }
		set {
			SpriteRenderer sr = GetComponentInChildren<SpriteRenderer> ();
			type = value;
			sr.sprite = getSpriteByType (type);
		}
	}

	private Sprite getSpriteByType(ElementType t) {
		switch (t) {
		case ElementType.Glass:
			return glassSprite;
		case ElementType.Grid:
			return gridSprite;
		case ElementType.Mirror:
			return mirrorSprite;
		case ElementType.Wall:
			return wallSprite;
		case ElementType.Water:
			return waterSprite;
		}
		return null;
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		box = GetComponent<Transform> ();
		collid = GetComponent<BoxCollider2D> ();

		SpriteRenderer sr = GetComponentInChildren<SpriteRenderer> ();

		sr.sprite = getSpriteByType (type);
	}
	
	// Update is called once per frame
	void Update () {

	}

	bool reflect(ProjektilCtrl.ProjektilType pt) {
		if (pt == ProjektilCtrl.ProjektilType.Parti) {
			switch (type) {
			case ElementType.Glass:
				return true;
			case ElementType.Grid:
				return true;
			case ElementType.Mirror:
				return false;
			case ElementType.Water:
				return false;
			case ElementType.Wall:
				return true;
			}
		} else {
			switch (type) {
			case ElementType.Glass:
				return false;
			case ElementType.Grid:
				return false;
			case ElementType.Mirror:
				return true;
			case ElementType.Water:
				return true;
			case ElementType.Wall:
				return false;
			}
		}
		return true;
	}

	bool destroyProjectile(ProjektilCtrl.ProjektilType pt) {
		if (pt == ProjektilCtrl.ProjektilType.Parti) {
			switch (type) {
			case ElementType.Glass:
				return false;
			case ElementType.Grid:
				return false;
			case ElementType.Mirror:
				return false;
			case ElementType.Water:
				return true;
			case ElementType.Wall:
				return false;
			}
		} else { // WAVE
			switch (type) {
			case ElementType.Glass:
				return false;
			case ElementType.Grid:
				return false;
			case ElementType.Mirror:
				return false;
			case ElementType.Water:
				return false;
			case ElementType.Wall:
				return true;
			}
		}
		return false;
	}

	bool destroyElement(ProjektilCtrl.ProjektilType pt) {
		if (pt == ProjektilCtrl.ProjektilType.Parti) {
			switch (type) {
			case ElementType.Glass:
				return false;
			case ElementType.Grid:
				return false;
			case ElementType.Mirror:
				return true;
			case ElementType.Water:
				return false;
			case ElementType.Wall:
				return false;
			}
		} else { // WAVE
			switch (type) {
			case ElementType.Glass:
				return false;
			case ElementType.Grid:
				return false;
			case ElementType.Mirror:
				return false;
			case ElementType.Water:
				return false;
			case ElementType.Wall:
				return false;
			}
		}
		return false;
	}

	void OnTriggerEnter2D(Collider2D col){
		// TODO Play sound depending on what happens. Destroyed, Glas, ...
		//AudioSource.PlayClipAtPoint (bounceSound, new Vector3 (0, 0, 0));

		Debug.Log ("Triggered!");

		if (col.gameObject.name.Equals("Projektil(Clone)")) {
			ProjektilCtrl pro = col.gameObject.GetComponent<ProjektilCtrl> ();
			//projektilHideElement (col.gameObject);
			//if(pro.type == ProjektilCtrl.ProjektilType.Wave)
			if(!reflect(pro.type))
				Physics2D.IgnoreCollision (col, GetComponent<Collider2D>(), true);
			if (destroyProjectile(pro.type))
				Destroy (col.gameObject);
			if (destroyElement (pro.type))
				Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		AudioSource.PlayClipAtPoint (bounceSound, new Vector3 (0, 0, 0));

		Debug.Log ("Collided!");

		if (col.gameObject.name.Equals("Projektil(Clone)")) {
			ProjektilCtrl pro = col.gameObject.GetComponent<ProjektilCtrl> ();

			//projektilHideElement (col.gameObject);
			//col.enabled = false;
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		Debug.Log ("Exit");
		Physics2D.IgnoreCollision (col.collider, GetComponent<Collider2D>(), false);
	}

	void OnMouseDown() {
		Vector2 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 vec = new Vector2 (mouse.x - rb.transform.position.x, mouse.y - rb.transform.position.y);
		float rot = Vector2.Angle (vec, new Vector2 (0, 1));
		if (vec.x > 0)
			rot *= -1;
		relRot = (box.rotation.eulerAngles.z) - rot;
		//if (relRot < -180)
//			relRot = 360 - relRot;
	}

	void OnMouseDrag() {
		Vector2 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 vec = new Vector2 (mouse.x - rb.transform.position.x, mouse.y - rb.transform.position.y);
		float rot = Vector2.Angle (vec, new Vector2 (0, 1));
		if (vec.x > 0)
			rot *= -1;
		rot += relRot;
//		if (rot < -180)
//			rot = 360 - rot;
		box.rotation = Quaternion.Euler(0, 0, rot);
	}

}
