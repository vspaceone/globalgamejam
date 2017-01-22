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

	public void restartLevel(){
		Application.LoadLevel (Application.loadedLevelName);
	}
}
