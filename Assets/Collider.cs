using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour {

	public GameObject player;
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D c)
	{

		Debug.Log ("sds");
		Debug.Log (c.gameObject.tag);

		if (c.gameObject.tag == "Player") {
			Debug.Log ("pop");

		}


	}
}
