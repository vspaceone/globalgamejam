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
	private float relRot;

	public ElementType type;
	public Sprite glassSprite;
	public Sprite mirrorSprite;
	public Sprite wallSprite;
	public Sprite gridSprite;
	public Sprite transformSprite;
	public AudioClip bounceSound;
	public Collider2D collider;

	private ProjektilCtrl.ProjektilType lastProjektilType;

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
		rb = GetComponent<Rigidbody2D> ();
		box = GetComponent<Transform> ();
		collider = (Collider2D) GetComponent<BoxCollider2D> ();


		SpriteRenderer sr = GetComponentInChildren<SpriteRenderer> ();

		sr.sprite = getSpriteByType (type);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void updateProjektilType( ProjektilCtrl.ProjektilType t ){

		if (t == ProjektilCtrl.ProjektilType.Parti) {
			updateForParticle ();
		} else {
			updateForWave ();
		}
		lastProjektilType = t;

	}


	void updateForParticle(){
		Debug.Log ("update for particle");
		switch (type) {
		case ElementType.Glass:

			break;
		case ElementType.Grid:

			break;
		case ElementType.Mirror:
			collider.isTrigger = true;
			break;
		case ElementType.Transform:

			break;
		case ElementType.Wall:
			collider.isTrigger = false;
			break;
		}
	}

	void updateForWave(){
		Debug.Log ("update for wave");
		switch (type) {
		case ElementType.Glass:
			collider.isTrigger = true;
			break;
		case ElementType.Grid:

			break;
		case ElementType.Mirror:
			collider.isTrigger = false;
			break;
		case ElementType.Transform:

			break;
		case ElementType.Wall:

			break;
		}
	}

	void projektilHideElement(GameObject obj){
		if (lastProjektilType == ProjektilCtrl.ProjektilType.Parti) {
			switch (type) {
			case ElementType.Glass:
				Destroy (gameObject);
				break;
			case ElementType.Grid:

				break;
			case ElementType.Mirror:
				Destroy (gameObject);
				break;
			case ElementType.Transform:

				break;
			case ElementType.Wall:

				break;
			}
		} else { // WAVE
			switch (type) {
			case ElementType.Glass:

				break;
			case ElementType.Grid:

				break;
			case ElementType.Mirror:

				break;
			case ElementType.Transform:

				break;
			case ElementType.Wall:
				Destroy(obj);
				break;
			}
		}

	}


	void OnTriggerEnter2D(Collider2D col){
		// TODO Play sound depending on what happens. Destroyed, Glas, ...
		//AudioSource.PlayClipAtPoint (bounceSound, new Vector3 (0, 0, 0));

		Debug.Log ("Triggered!");

		if (col.gameObject.name.Equals("Projektil(Clone)")) {
			projektilHideElement (col.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		AudioSource.PlayClipAtPoint (bounceSound, new Vector3 (0, 0, 0));

		Debug.Log ("Collided!");

		if (col.gameObject.name.Equals("Projektil(Clone)")) {
			projektilHideElement (col.gameObject);
		}
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
