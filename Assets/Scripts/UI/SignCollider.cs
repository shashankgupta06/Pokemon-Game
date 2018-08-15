using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignCollider : MonoBehaviour {

	public GameObject player;
	public Text townText;
	public GameObject canvas;
	// Update is called once per frame



	void Awake()        //take this out later
	{
		player = GameObject.Find ("Player");
		canvas = player.transform.GetChild(0).transform.GetChild(0).gameObject;
		townText = canvas.transform.GetChild (0).transform.Find ("Text").GetComponent<Text> ();


	}

	void OnLevelWasLoaded()
	{

		player = GameObject.Find ("Player");
		canvas = player.transform.GetChild(0).transform.GetChild(0).gameObject;
		townText = canvas.transform.GetChild (0).transform.Find ("Text").GetComponent<Text> ();

		//Debug.Log (player.transform.Find("EnterTownSign/Text").GetComponent<Text>().text);

	}


	void OnTriggerEnter2D(Collider2D c)
	{
		if (player.GetComponent<SpriteRenderer> ().sprite.name == "North_0" || player.GetComponent<SpriteRenderer> ().sprite.name == "North_1" || player.GetComponent<SpriteRenderer> ().sprite.name == "North_2") {
			canvas.GetComponent<Canvas> ().enabled = true;
			canvas.GetComponentInChildren<Text> ().text = gameObject.GetComponent<Text> ().text;
		}
	}

	void OnTriggerExit2D(Collider2D c){
		canvas.GetComponent<Canvas> ().enabled = false;
	}
}
