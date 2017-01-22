using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnProjektilDestroyed( GameObject projektil ){

		Debug.Log ("OnProjektilDestroyed called");
		GameObject[] remainingProjektils = GameObject.FindGameObjectsWithTag ("Projektil");
		Debug.Log ("RemainingProjektils: " + remainingProjektils.Length);
		if (remainingProjektils.Length == 0) {
			// Reload Game
			Debug.Log("Starting Level...");
			GameObject[] objs = GameObject.FindObjectsOfType<GameObject>();
			foreach (GameObject obj in objs) {
				obj.SendMessage ("OnRestartLevel", gameObject, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
		
}
