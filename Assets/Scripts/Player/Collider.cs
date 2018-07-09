using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collider : MonoBehaviour {

	public GameObject player;
	public Text townText;
	public GameObject canvas;
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D c)
	{
		if (player.GetComponent<SpriteRenderer> ().sprite.name == "South_0") {
			canvas.SetActive (true);
			canvas.GetComponentInChildren<Text> ().text = gameObject.GetComponent<Text> ().text;
		}
    }

	void OnTriggerExit2D(Collider2D c){
		canvas.SetActive (false);
	}
}
