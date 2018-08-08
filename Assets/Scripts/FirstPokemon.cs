using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstPokemon : MonoBehaviour
{

	private GameObject player;
	private string pokeball;

	void OnTriggerEnter2D(Collider2D c){
		pokeball = gameObject.name;

	}


	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update()
	{


		if (player.GetComponent<BoxCollider2D> ().IsTouching (gameObject.GetComponent<BoxCollider2D> ()) && (player.GetComponent<SpriteRenderer>().sprite.name == "North_1" || player.GetComponent<SpriteRenderer>().sprite.name == "North_2") ) {
			if(Input.GetKeyDown(KeyCode.Return)){
				switch (pokeball) {

				case  "pokeball":
					Debug.Log ("Squirtle");
					PokemonPickScene ("Squirtle");
					break;
				case "pokeball (3)":
					Debug.Log ("Charmander");
					PokemonPickScene ("Charmander");
					break;
				case "pokeball (1)":
					Debug.Log ("Bulbasaur");
					PokemonPickScene ("Bulbasaur");
					break;

					default:
					break;


				}


			}

		}

	}



	void PokemonPickScene(string pokemonName)
	{
		PlayerPrefs.SetString ("FirstPokemon", pokemonName);
		SceneManager.LoadScene ("FirstPokemon");

	}

}
