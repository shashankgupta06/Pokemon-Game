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

	void OnLevelWasLoaded ()
	{
		player = GameObject.Find ("Player");
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
				break;

			case "PlayerHouseTop":
				yield return new WaitForSeconds (n);
				player.transform.position = new Vector2 (6, 5);
				player.GetComponent<SpriteRenderer> ().sprite = westSprite;
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
				break;

			case "FirstPokemon":
				switch (pokemonOption) {

				case "Charmander":
					yield return new WaitForSeconds (n);
					player.transform.position = new Vector2 (6, 10);
					break;

				case "Squirtle":
					yield return new WaitForSeconds (n);
					player.transform.position = new Vector2 (4, 10);
					break;

				case "Bulbasaur":
					yield return new WaitForSeconds (n);
					player.transform.position = new Vector2 (5, 10);
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
			break;



		case "PlayerHouseTop":
			Debug.Log ("pop");
			switch (LastScene) {
			case "OakWalkThrough":
				yield return new WaitForSeconds (n);
				player.transform.position = new Vector2 (-5, 1);
				break;

			case "PlayerHouseBottom":
				Debug.Log ("popu");
				yield return new WaitForSeconds (n);
				player.transform.position = new Vector2 (5, 4);
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
