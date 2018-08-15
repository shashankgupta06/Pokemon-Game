using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colliders : MonoBehaviour {


	public GameObject player;
	public Text townText;
	public GameObject canvas;

	// Use this for initialization


	void OnLevelWasLoaded()
	{
		player = GameObject.Find ("Player");
		canvas = player.transform.GetChild(0).transform.GetChild(0).gameObject;
		townText = canvas.transform.GetChild (0).transform.Find ("Text").GetComponent<Text> ();
	}
	
	void OnTriggerEnter2D(Collider2D c)
	{
		switch (gameObject.name) {

		case "PalletTown":
			if (player.GetComponent<SpriteRenderer> ().sprite.name == "North_0" || player.GetComponent<SpriteRenderer> ().sprite.name == "North_1" || player.GetComponent<SpriteRenderer> ().sprite.name == "North_2") {
				canvas.GetComponent<Canvas> ().enabled = true;
				canvas.GetComponentInChildren<Text> ().text = "Route 1";
			} else if (player.GetComponent<SpriteRenderer> ().sprite.name == "South_0" || player.GetComponent<SpriteRenderer> ().sprite.name == "South_1" || player.GetComponent<SpriteRenderer> ().sprite.name == "South_2") {
				canvas.GetComponent<Canvas> ().enabled = true;
				canvas.GetComponentInChildren<Text> ().text = "Pallet Town";
			}

			break;

		default:
			break;

		}


	}


	void OnTriggerExit2D(Collider2D c)
	{
		canvas.GetComponent<Canvas> ().enabled = false;
	}


}
