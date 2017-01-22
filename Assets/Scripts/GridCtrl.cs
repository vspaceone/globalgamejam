using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCtrl : MonoBehaviour {
	//public GameObject 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit2D(Collider2D col){
		// TODO Play sound depending on what happens. Destroyed, Glas, ...
		//AudioSource.PlayClipAtPoint (bounceSound, new Vector3 (0, 0, 0));

		Debug.Log ("Grid Triggered!");

		if (col.gameObject.name.Equals("Projektil(Clone)")) {
			ProjektilCtrl pro = col.gameObject.GetComponent<ProjektilCtrl> ();
			Rigidbody2D rig = pro.GetComponent<Rigidbody2D> ();
			Debug.Log ("passed through: " + rig.velocity);
			Vector2 vel = rig.velocity;
			float speed = vel.magnitude;
			Vector2 dir = vel.normalized;

			GameObject projektil = (GameObject)Instantiate (col.gameObject);
			projektil.name = "Projektil(Clone)";
			Rigidbody2D rig2 = projektil.GetComponent<Rigidbody2D> ();

			rig.velocity = Quaternion.Euler (0, 0, -30) * dir * speed;
			rig2.velocity = Quaternion.Euler (0, 0, 30) * dir * speed;
		}
	}

}
