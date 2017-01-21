using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjektilCtrl : MonoBehaviour {

	public enum ProjektilType{
		Parti,
		Wave,
	}
		
	private ProjektilType type = ProjektilType.Parti;
	public Sprite particleSprite;
	public Sprite waveSprite;			
	private SpriteRenderer sr;

	private Rigidbody2D rb;
	private Animator animator;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		sr = GetComponentInChildren<SpriteRenderer> ();


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
			Debug.Log ("Wave now!");
			type = ProjektilType.Wave;
			sr.sprite = waveSprite;
		} else if (type == ProjektilType.Wave) {
			Debug.Log ("Parti now!");
			type = ProjektilType.Parti;
			sr.sprite = particleSprite;
		} else {
			Debug.LogError ("Unknown type of projektil!");
		}
	}
}
