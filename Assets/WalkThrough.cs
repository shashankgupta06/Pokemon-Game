using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WalkThrough : MonoBehaviour {

	public Text WalkThroughText;
	private int TextNumber=0;
	string playerName;


	void Start()
	{
		playerName = PlayerPrefs.GetString ("PlayerName","");
	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.Return)) {

			switch (TextNumber) 
			{

			case 0:
				WalkThroughText.text = "I am professor OAK and welcome to the world of POKEMON";
				TextNumber++;
				break;

			
			case 1:
				WalkThroughText.text = "This world is inhabited far and wide by various different kinds of POKEMON";
				TextNumber++;
				break;

			case 2:
				WalkThroughText.text = "Some use POKEMON as pets where as othr use them for battling";
				TextNumber++;
				break;

			case 3:
				WalkThroughText.text = "As for me, I study POKEMON as a profession";
				TextNumber++;
				break;

			case 4:
				WalkThroughText.text = "So " + playerName + ", I understand you want to be a POKEMON master! I wish you all the best on your journey!";
				TextNumber++;
				break;
			
			
			case 5:
				SceneManager.LoadScene ("Main");
				break;
			
			default:
				break;

			}



		}


	}
}
