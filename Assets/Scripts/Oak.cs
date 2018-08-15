using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oak : MonoBehaviour
{

	public GameObject player;

	private string playerName;
	private int textNumber;
	private string pokemonName;


	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnLevelWasLoaded()
	{

		if (player.GetComponent<Player> ().ownedPokemon.Count == 0) {
			textNumber = 0;
		} else {
			textNumber = 5;
			pokemonName = player.GetComponent<Player> ().ownedPokemon [0].NickName;

		}
	}


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

				case 3:
					player.transform.Find ("Main Camera/PlayerInteraction/Interaction/Text").gameObject.GetComponent<Text> ().text = "Goodluck";
					textNumber++;
					break;

				case 4:
					player.transform.Find ("Main Camera/PlayerInteraction").gameObject.SetActive (false);
					textNumber = 0;
					break;

				case 5:
					player.transform.Find ("Main Camera/PlayerInteraction/Interaction/Text").gameObject.GetComponent<Text> ().text = "Take care of that " + pokemonName;
					textNumber++;
					break;

				case 6:
					player.transform.Find ("Main Camera/PlayerInteraction").gameObject.SetActive (false);
					textNumber = 5;
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
