using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementCtrl : MonoBehaviour {
	public enum ElementType
	{
		Glass,
		Mirror,
		Wall,
		Grid,
		Transform,
	}
	private Rigidbody2D rb; 

	public ElementType type;
	public Sprite glassSprite;
	public Sprite mirrorSprite;
	public Sprite wallSprite;
	public Sprite gridSprite;
	public Sprite transformSprite;
	public AudioClip bounceSound;

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
		case ElementType.Transform:
			return transformSprite;
		case ElementType.Wall:
			return wallSprite;
		}
		return null;
	}

	// Use this for initialization
	void Start () {
		SpriteRenderer sr = GetComponentInChildren<SpriteRenderer> ();
		sr.sprite = getSpriteByType (type);
		//CircleCollider2D col = GetComponent<CircleCollider2D> ();
		//col.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		rb = GetComponent<Rigidbody2D> ();
		box = GetComponent<Transform> ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		AudioSource.PlayClipAtPoint (bounceSound, new Vector3 (0, 0, 0));
	}

	void OnMouseDrag() {
		Vector2 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 vec = new Vector2 (mouse.x - rb.transform.position.x, mouse.y - rb.transform.position.y);
		float rot = Vector2.Angle (vec, new Vector2 (0, 1));
		if (vec.x > 0)
			rot *= -1;
		Debug.Log("Pos " + Input.mousePosition + " " + vec + " " + rot);
		box.rotation = Quaternion.Euler(0, 0, rot);
	}

}
