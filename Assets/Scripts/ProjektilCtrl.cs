using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjektilCtrl : MonoBehaviour {

	public enum ProjektilType{
		Parti,
		Wave,
	}
		
	public Sprite particleSprite;
	public Sprite waveSprite;


	public ProjektilType type;
	public ProjektilType Type {
		get { return type; }
		set {
			SpriteRenderer sr = GetComponentInChildren<SpriteRenderer> ();
			type = value;
			if (type == ProjektilType.Parti) {
				sr.sprite = particleSprite;
			} else if (type == ProjektilType.Wave) {
				sr.sprite = waveSprite;
			} else {
				Debug.LogError ("Unknown type of projektil!");
			}
				
		}
	}

	private Rigidbody2D rb;
	private Animator animator;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();


		type = ProjektilType.Parti;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if (Input.GetKeyDown ("t")) {
			Debug.Log ("Toggling projektil type");
			toggleType ();
		}
		
	}

	void toggleType(){
		if (type == ProjektilType.Parti) {
			type = ProjektilType.Wave;
		} else if (type == ProjektilType.Wave) {
			type = ProjektilType.Parti;
		} else {
			Debug.LogError ("Unknown type of projektil!");
		}
	}
}
