using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeCtrl : MonoBehaviour {


	public float maxGravDist = 4.0f;
	public float maxGravity = 35.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {

		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Projektil");
		foreach(GameObject projektil in objs) {
			float dist = Vector3.Distance(projektil.transform.position, transform.position);
			if (dist <= maxGravDist) {
				Vector3 v = projektil.transform.position - transform.position;
				projektil.GetComponent<Rigidbody2D>().AddForce(v.normalized * (1.0f - dist / maxGravDist) * maxGravity);
			}
		}

	}
}
