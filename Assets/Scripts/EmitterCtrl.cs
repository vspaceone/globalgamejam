using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterCtrl : MonoBehaviour {

	public GameObject projektilPrefab;
	public Transform spawnPoint;
	public float reloadTime = 4;
	public float shootpower = 500;

	private Rigidbody2D rb;
	private Animator animator;
	private GameObject projektil;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0) && projektil == null ) {
			projektil = (GameObject)Instantiate (projektilPrefab, spawnPoint.position, Quaternion.identity);
			projektil.GetComponent<Rigidbody2D> ().AddForce (Vector3.right * shootpower);
		}

	}

	void FixedUpdate(){

	}

}
