using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPokemonScene : MonoBehaviour
{

	public Sprite Bulbasaur, Charmander, Squirtle;
	public Text pokemonName;
	public Text pokemonBaseStats;
	public Transform charmander;

	private string pokemon;

	// Use this for initialization
	void Awake ()
	{
		pokemon = PlayerPrefs.GetString ("FirstPokemon", "");
		GameObject.Instantiate (charmander);
		Debug.Log (pokemon);
	}
	
	// Update is called once per frame
	void Update ()
	{

		switch (pokemon) {

		case "Squirtle":
			gameObject.GetComponent<Image> ().sprite = Squirtle;
			PokemonStats (pokemon);

			break;

		case "Charmander":
			gameObject.GetComponent<Image> ().sprite = Charmander;
			PokemonStats (pokemon);
			break;

		case "Bulbasaur":
			gameObject.GetComponent<Image> ().sprite = Bulbasaur;
			PokemonStats (pokemon);
			break;

		default:
			break;

		}
		
	}



	void PokemonStats(string pokemon)
	{

		pokemonName.text = pokemon;

		pokemonBaseStats.text = "HP: " + charmander.GetComponent<BasePokemon> ().HP + "\n" +
		"Attack: " + charmander.GetComponent<BasePokemon> ().pokemonStats.attackStat + "\n" +
		"Defence: " + charmander.GetComponent<BasePokemon> ().pokemonStats.defenceStat + "\n" +
		"Sp.Attack: " + charmander.GetComponent<BasePokemon> ().pokemonStats.spAttackStat + "\n" +
		"Sp.Defence: " + charmander.GetComponent<BasePokemon> ().pokemonStats.spDefenceStat + "\n" +
		"speed: " + charmander.GetComponent<BasePokemon> ().pokemonStats.speedStat;

	}
}
