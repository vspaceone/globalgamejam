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
	public Collider2D collid;

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
		collid = (Collider2D) GetComponent<BoxCollider2D> ();


		SpriteRenderer sr = GetComponentInChildren<SpriteRenderer> ();

		sr.sprite = getSpriteByType (type);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void updateProjektilType( ProjektilCtrl.ProjektilType t ){
/*
		if (t == ProjektilCtrl.ProjektilType.Parti) {
			updateForParticle ();
		} else {
			updateForWave ();
		}
		lastProjektilType = t;
*/
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
			case ElementType.Transform:
				return true;
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
			case ElementType.Transform:
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
			case ElementType.Transform:
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
			case ElementType.Transform:
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
			case ElementType.Transform:
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
			case ElementType.Transform:
				return false;
			case ElementType.Wall:
				return false;
			}
		}
		return false;
	}

	/*
	void updateForParticle(){
		return;
		Debug.Log ("update for particle");
		switch (type) {
		case ElementType.Glass:
			// reflected
			// quit good glass!
			collid.isTrigger = false;
			break;
		case ElementType.Grid:
			// reflected
			collid.isTrigger = false;
			break;
		case ElementType.Mirror:
			// Destroyes mirror
			collid.isTrigger = true;
			break;
		case ElementType.Transform:
			// reflected
			collid.isTrigger = false;
			break;
		case ElementType.Wall:
			// reflected
			collid.isTrigger = false;
			break;
		}
	}

	void updateForWave(){
		return;
		Debug.Log ("update for wave");
		switch (type) {
		case ElementType.Glass:
			// not affected
			collid.isTrigger = true;
			break;
		case ElementType.Grid:
			// reflected
			collid.isTrigger = true;
			break;
		case ElementType.Mirror:
			// reflected
			collid.isTrigger = false;
			break;
		case ElementType.Transform:
			// reflected
			collid.isTrigger = false;
			break;
		case ElementType.Wall:
			// absorbed
			collid.isTrigger = true;
			break;
		}
	}
	void projektilHideElement(GameObject obj){

		// PARTICLE
		if (lastProjektilType == ProjektilCtrl.ProjektilType.Parti) {
			switch (type) {
			case ElementType.Glass:
				// reflected
				// quit good glass!
				break;
			case ElementType.Grid:
				// reflected
				break;
			case ElementType.Mirror:
				// Destroyes mirror
				Destroy (gameObject);
				break;
			case ElementType.Transform:
				// reflected
				break;
			case ElementType.Wall:
				// reflected
				break;
			}
		} else { // WAVE
			switch (type) {
			case ElementType.Glass:
				// not affected
				break;
			case ElementType.Grid:
				// reflected
				break;
			case ElementType.Mirror:
				// reflected
				break;
			case ElementType.Transform:
				// reflected
				break;
			case ElementType.Wall:
				// absorbed
				Destroy(obj);
				break;
			}
		}

	}

	*/

	void OnTriggerEnter2D(Collider2D col){
		// TODO Play sound depending on what happens. Destroyed, Glas, ...
		//AudioSource.PlayClipAtPoint (bounceSound, new Vector3 (0, 0, 0));

		Debug.Log ("Triggered!");

		if (col.gameObject.name.Equals("Projektil(Clone)")) {
			ProjektilCtrl pro = col.gameObject.GetComponent<ProjektilCtrl> ();
			lastProjektilType = pro.type;
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
			lastProjektilType = pro.type;
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
