using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPositioner : MonoBehaviour {


	public Sprite northSprite;
	public Sprite westSprite;
	public GameObject player;
	string LastScene;

	void Awake () {
		LastScene = PlayerPrefs.GetString ("LastScene", "");
		Debug.Log (LastScene);


		if (LastScene == "main") {
			player.transform.position = new Vector3 (-5, -4, 0);
			player.GetComponent<SpriteRenderer> ().sprite = northSprite;
		} else if (LastScene == "PlayerHouseTop") {
			player.transform.position = new Vector3 (5.5f, 4.5f, 0);
			player.GetComponent<SpriteRenderer> ().sprite = westSprite;
		}
	}

}
