using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCtrl : MonoBehaviour {

	private Renderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponentInChildren<Renderer> ();

		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnVictory( GameObject obj){
		Debug.Log ("OnVictory called!");
		renderer.enabled = true;
	}
}
