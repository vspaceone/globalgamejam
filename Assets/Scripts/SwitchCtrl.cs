using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCtrl : MonoBehaviour {

	public enum Type
	{
		Particle,
		Wave,
		Both
	}
	public GameObject actor = null;
	public Type triggerType = Type.Both;
	//public bool anihilate = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D col){
		// TODO Play sound depending on what happens. Destroyed, Glas, ...
		//AudioSource.PlayClipAtPoint (bounceSound, new Vector3 (0, 0, 0));

		Debug.Log ("Switch Triggered!");

		if (col.gameObject.name.Equals("Projektil(Clone)")) {
			ProjektilCtrl pro = col.gameObject.GetComponent<ProjektilCtrl> ();

			bool isTriggered = false;
			if (pro.type == ProjektilCtrl.ProjektilType.Parti && (triggerType == Type.Both || triggerType == Type.Particle)) {
				isTriggered = true;
			} else if (pro.type == ProjektilCtrl.ProjektilType.Wave && (triggerType == Type.Both || triggerType == Type.Wave)) {
				isTriggered = false;
			}

			if (isTriggered) {
				if(actor != null)
					actor.SendMessage ("SwitchActivated");
//				if (anihilate)
				Destroy (col.gameObject);
			}
		}
	}

}
