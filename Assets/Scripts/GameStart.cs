using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart: MonoBehaviour {


	public Sprite northSprite;
	public Sprite eastSprite;
	public Player player;
	string LastScene;

	void Awake () {
		LastScene = PlayerPrefs.GetString ("LastScene", "");
		Debug.Log (LastScene);
		player = FindObjectOfType<Player>();

		if (LastScene == "PlayerHouseBottom") {
			player.transform.position = new Vector3 (5, 4, 0);
			player.GetComponent<SpriteRenderer> ().sprite = eastSprite;
		} else if (LastScene == "OakWalkThrough") {
			player.transform.position = new Vector3 (-5, 1f, 0);
			player.GetComponent<SpriteRenderer> ().sprite = northSprite;
		}
	}

}
