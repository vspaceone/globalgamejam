using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCtrl : MonoBehaviour {

	public enum TargetType {
		NormalTarget,
		ParticleTarget,
		WaveTarget
	}

	public TargetType type;
	public AudioClip targetSound;
	public AudioClip failedSound;


	public Sprite normalSprite;
	public Sprite particleSprite;
	public Sprite waveSprite;

	private Rigidbody2D rb;
	private Animator animator;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		SpriteRenderer sr = GetComponentInChildren<SpriteRenderer> ();

		switch (type) {
		case TargetType.NormalTarget:
			sr.sprite = normalSprite;
			break;
		case TargetType.ParticleTarget:
			sr.sprite = particleSprite;
			break;
		case TargetType.WaveTarget:
			sr.sprite = waveSprite;
			break;
		}

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		//Check collision name
		Debug.Log("collision name = " + col.gameObject.name);
		if (col.gameObject.name.Equals("Projektil(Clone)")) {
			ProjektilCtrl pro = col.gameObject.GetComponent<ProjektilCtrl> ();
			if (pro.type == ProjektilCtrl.ProjektilType.Parti && type == TargetType.WaveTarget) {
				// Not ok!
				AudioSource.PlayClipAtPoint (failedSound, new Vector3 (0, 0, 0));
				Destroy (col.gameObject);
			} else if (pro.type == ProjektilCtrl.ProjektilType.Wave && type == TargetType.ParticleTarget) {
				// Not ok!
				AudioSource.PlayClipAtPoint (failedSound, new Vector3 (0, 0, 0));
				Destroy (col.gameObject);
			} else {
				Debug.Log ("Win!");
				AudioSource.PlayClipAtPoint (targetSound, new Vector3 (0, 0, 0));
				Destroy (col.gameObject);
			}
		}
	}

	// Update is called once per frame
	void Update () {
				
	}

	void FixedUpdate(){

	}

}
