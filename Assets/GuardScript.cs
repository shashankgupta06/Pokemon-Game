using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardScript : MonoBehaviour {

	private GameObject player;
	public int textNumber;

	// Use this for initialization
	void OnLevelWasLoaded()
	{
		textNumber = 0;
		player = GameObject.FindGameObjectWithTag ("Player");

		if (player.GetComponent<Player> ().ownedPokemon.Count != 0) 
		{
			gameObject.transform.position = new Vector3 (-2.5f, -17.5f, 0);
			textNumber = 2;
		}


	}
	
	// Update is called once per frame
	void Update () {

		if (player.GetComponent<BoxCollider2D> ().IsTouching (gameObject.GetComponent<BoxCollider2D> ())) {

			if (Input.GetKeyDown (KeyCode.Return)) {
				player.transform.Find ("Main Camera/PlayerInteraction").gameObject.SetActive (true);
				switch (gameObject.name) {

				case "PalletTownGuard":
					switch (textNumber) {

					case 0:
						player.transform.Find ("Main Camera/PlayerInteraction/Interaction/Text").gameObject.GetComponent<Text> ().text = "You need a pokemon to enter Route 1";
						textNumber++;
						break;
					case 1:
						player.transform.Find ("Main Camera/PlayerInteraction").gameObject.SetActive (false);
						textNumber = 0;
						break;

					case 2:
						player.transform.Find ("Main Camera/PlayerInteraction/Interaction/Text").gameObject.GetComponent<Text> ().text = "Enjoy!";
						textNumber++;
						break;

					case 3:
						player.transform.Find ("Main Camera/PlayerInteraction").gameObject.SetActive (false);
						textNumber = 2;
						break;

					default:
						break;


					}

					break;

				default:
					break;



				}

			}



		} else {
			player.transform.Find ("Main Camera/PlayerInteraction").gameObject.SetActive (false);
		}


	}
		

}
