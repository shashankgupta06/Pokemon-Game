using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositioner : MonoBehaviour
{

	public Sprite northSprite;
	public Sprite westSprite;
	public GameObject player;
	string LastScene;
	string pokemonOption;

	private GameObject imageBetweenScenes;

	void OnLevelWasLoaded ()
	{
		
		player = GameObject.Find ("Player");
		imageBetweenScenes = player.transform.Find ("Main Camera/ImageBetweenScenes").gameObject;
		player.GetComponent<PlayerMovement> ().isAllowedToMove = false;
		imageBetweenScenes.SetActive (true);
		imageBetweenScenes.SetActive (true);
		LastScene = PlayerPrefs.GetString ("LastScene", "");
		pokemonOption = PlayerPrefs.GetString ("PokemonOption", "");
		StartCoroutine (Wait (0.5f));

	}

	void Update ()
	{
		
	}

	IEnumerator Wait (float n)
	{
		switch (SceneManager.GetActiveScene ().name) {

		case "PlayerHouseBottom":
			switch (LastScene) {
			case "MainGame":
				yield return new WaitForSeconds (n);
				player.transform.position = new Vector2 (-5, -4);
				player.GetComponent<PlayerMovement> ().isAllowedToMove = true;
				imageBetweenScenes.SetActive (false);
				break;

			case "PlayerHouseTop":
				yield return new WaitForSeconds (n);
				player.transform.position = new Vector2 (6, 5);
				player.GetComponent<SpriteRenderer> ().sprite = westSprite;
				player.GetComponent<PlayerMovement> ().isAllowedToMove = true;
				imageBetweenScenes.SetActive (false);
				break;

			default:
				break;

			}
			break;

		case "OakLab":
			switch (LastScene) {
			case "MainGame":
				yield return new WaitForSeconds (n);
				player.transform.position = new Vector2 (0, 1);
				player.GetComponent<PlayerMovement> ().isAllowedToMove = true;
				imageBetweenScenes.SetActive (false);
				break;

			case "FirstPokemon":
				switch (pokemonOption) {

				case "Charmander":
					yield return new WaitForSeconds (n);
					player.transform.position = new Vector2 (6, 10);
					player.GetComponent<PlayerMovement> ().isAllowedToMove = true;
					break;

				case "Squirtle":
					yield return new WaitForSeconds (n);
					player.transform.position = new Vector2 (4, 10);
					player.GetComponent<PlayerMovement> ().isAllowedToMove = true;
					imageBetweenScenes.SetActive (false);
					break;

				case "Bulbasaur":
					yield return new WaitForSeconds (n);
					player.transform.position = new Vector2 (5, 10);
					player.GetComponent<PlayerMovement> ().isAllowedToMove = true;
					imageBetweenScenes.SetActive (false);
					break;
				
				default:
					break;
				}
				break;

			default:
				break;
			}
			break;


		case "GarysHouse":
			yield return new WaitForSeconds (n);
			player.transform.position = new Vector2 (-5, -4);
			player.GetComponent<PlayerMovement> ().isAllowedToMove = true;
			imageBetweenScenes.SetActive (false);
			break;



		case "PlayerHouseTop":
			Debug.Log ("pop");
			switch (LastScene) {
			case "OakWalkThrough":
				yield return new WaitForSeconds (n);
				player.transform.position = new Vector2 (-5, 1);
				player.GetComponent<PlayerMovement> ().isAllowedToMove = true;
				imageBetweenScenes.SetActive (false);
				break;

			case "PlayerHouseBottom":
				Debug.Log ("popu");
				yield return new WaitForSeconds (n);
				player.transform.position = new Vector2 (5, 4);
				player.GetComponent<PlayerMovement> ().isAllowedToMove = true;
				imageBetweenScenes.SetActive (false);
				break;

			default:
				break;
			}
			break;

		default:
			break;
		}

	}
}
