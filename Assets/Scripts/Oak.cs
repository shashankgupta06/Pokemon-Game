using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oak : MonoBehaviour
{

	public GameObject player;

	private string playerName;
	private int textNumber = 0;


	void Start ()
	{

		playerName = PlayerPrefs.GetString ("PlayerName", "");

	}


	// Update is called once per frame
	void Update ()
	{

		if (player.GetComponent<BoxCollider2D> ().IsTouching (gameObject.GetComponent<BoxCollider2D> ())) {
			

			if (Input.GetKeyDown (KeyCode.Return)) {
				player.transform.Find ("Main Camera/PlayerInteraction").gameObject.SetActive (true);
				switch (textNumber) {

				case 0: 
					player.transform.Find ("Main Camera/PlayerInteraction/Interaction/Text").gameObject.GetComponent<Text> ().text = "Hi " + playerName;
					textNumber++;
					break;

				case 1:
					player.transform.Find ("Main Camera/PlayerInteraction/Interaction/Text").gameObject.GetComponent<Text> ().text = " I have 3 pokemon for you namely, a BULBASAUR, a CHARMANDER or a SQUIRTLE";
					textNumber++;
					break;
			
				case 2:
					player.transform.Find ("Main Camera/PlayerInteraction/Interaction/Text").gameObject.GetComponent<Text> ().text = "Make your choice carefully as this will be your first pokemon and they all have different characteristics";
					textNumber++;
					break;

				default:
					break;


				}
			}

		}
	}

	void OnTriggerExit2D (Collider2D c)
	{

		player.transform.Find ("Main Camera/PlayerInteraction").gameObject.SetActive (false);
	}
}
