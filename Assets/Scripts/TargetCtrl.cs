using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCtrl : MonoBehaviour {

	public enum TargetType {
		ParticleTarget,
		WaveTarget
	}

	public TargetType type;
	private Rigidbody2D rb;
	private Animator animator;
	public AudioClip targetSound;

	public Sprite glassSprite;
	public Sprite mirrorSprite;

	public TargetType Type {
		get { return type; }
		set {
			SpriteRenderer sr = GetComponentInChildren<SpriteRenderer> ();
			type = value;
			sr.sprite = getSpriteByType (type);
		}
	}

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
			AudioSource.PlayClipAtPoint (targetSound, new Vector3 (0, 0, 0));
			Destroy (col.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
				
	}

	void FixedUpdate(){

	}

}
