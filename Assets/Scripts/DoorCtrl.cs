using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCtrl : MonoBehaviour {

	public float openDuration = 2;

	private bool open = false;
	private float closeTime;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	void SwitchActivated() {
		//gameObject.SetActive (false);
		open = true;
		SpriteRenderer rd = GetComponentInChildren<SpriteRenderer> ();
		BoxCollider2D collid = GetComponent<BoxCollider2D> ();
		collid.isTrigger = true;
		rd.color = new Color (1.0f, 1.0f, 1.0f, 0.1f);
		closeTime = Time.fixedTime + openDuration;
		Debug.Log ("Start " + Time.fixedTime + " " + closeTime);
	}

	void FixedUpdate() {
		if (open) {
			if (Time.fixedTime > closeTime) {
				Debug.Log ("Ablauf");
				open = false;
				SpriteRenderer rd = GetComponentInChildren<SpriteRenderer> ();
				rd.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
				BoxCollider2D collid = GetComponent<BoxCollider2D> ();
				collid.isTrigger = false;
				//gameObject.SetActive (true);
			}
		}
	}
}
