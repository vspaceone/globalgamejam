using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
		StartCoroutine(Example());


	}
		
	IEnumerator Example() {
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
