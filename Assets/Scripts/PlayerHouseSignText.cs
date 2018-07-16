using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHouseSignText : MonoBehaviour {

	string playerName;
	public Text text;


	void Awake()
	{
		playerName = PlayerPrefs.GetString ("PlayerName","");
		text.text = playerName + "'s house";
		Debug.Log (playerName);

	}

}
