using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCtrl : MonoBehaviour {

	public AudioClip victorySound;

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
			Debug.Log("Restarting Level...");
			GameObject[] objs = GameObject.FindObjectsOfType<GameObject>();
			foreach (GameObject obj in objs) {
				obj.SendMessage ("OnRestartLevel", gameObject, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	void OnTargetDestroyed( GameObject target ){

		Debug.Log ("Target destroyed!");
		Debug.Log ("Level finished!");


		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Victory");
		foreach (GameObject obj in objs) {
			AudioSource.PlayClipAtPoint (victorySound, new Vector3 (0, 0, 0));
			obj.SendMessage ("OnVictory", gameObject, SendMessageOptions.DontRequireReceiver);
		}
	}
		
}
