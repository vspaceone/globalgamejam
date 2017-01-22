using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjektilCtrl : MonoBehaviour {

	public enum ProjektilType{
		Parti,
		Wave,
	}
		
	public ProjektilType type = ProjektilType.Parti;
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

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("t")) {
			Debug.Log ("Toggling projektil type");
			toggleType ();
		}

		Vector2 moveDirection = rb.velocity;
		if (moveDirection != Vector2.zero) {
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
		}
	}

	void FixedUpdate(){

		
	}

	public void toggleType(){
		if (type == ProjektilType.Parti) {
			type = ProjektilType.Wave;
			sr.sprite = waveSprite;
		} else if (type == ProjektilType.Wave) {
			type = ProjektilType.Parti;
			sr.sprite = particleSprite;
		} else {
			Debug.LogError ("Unknown type of projektil!");
		}
	}

	void OnDestroy(){
		//SceneManager.LoadScene(SceneManager.GetActiveScene().name);

		GameObject[] objs = GameObject.FindObjectsOfType<GameObject>();
		foreach (GameObject obj in objs) {
			obj.SendMessage ("OnProjektilDestroyed", gameObject, SendMessageOptions.DontRequireReceiver);
		}
	}

}
