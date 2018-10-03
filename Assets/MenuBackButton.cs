using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBackButton : MonoBehaviour {

	public Button backButton;
	public GameObject player;

	// Use this for initialization
	void Awake () {
		backButton.onClick.AddListener (TaskOnClick);
	}
	
	// Update is called once per frame
	void TaskOnClick() {
		player.GetComponent<PlayerMovement> ().isAllowedToMove = true;
		player.transform.Find ("Main Camera/Menu").gameObject.SetActive (false);
	}
}
