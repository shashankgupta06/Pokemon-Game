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
	public Transform squirtle;
	public Transform bulbasaur;

	private Transform Pokemon;
	private string pokemon;

	// Use this for initialization
	void Awake ()
	{
		pokemon = PlayerPrefs.GetString ("FirstPokemon", "");

		switch (pokemon) {

		case "Squirtle":
			gameObject.GetComponent<Image> ().sprite = Squirtle;
			Pokemon = squirtle;
			PokemonStats (pokemon);

		 	break;

		case "Charmander":
			gameObject.GetComponent<Image> ().sprite = Charmander;
			Pokemon = charmander;
			PokemonStats (pokemon);
			break;

		case "Bulbasaur":
			gameObject.GetComponent<Image> ().sprite = Bulbasaur;
			Pokemon = bulbasaur;
			PokemonStats (pokemon);
			break;

		default:
			break;

		}

		GameObject.Instantiate (Pokemon);
	}




	void PokemonStats(string pokemon)
	{

		pokemonName.text = pokemon;

		pokemonBaseStats.text = "HP: " + Pokemon.GetComponent<BasePokemon> ().HP + "\n" +
			"Attack: " + Pokemon.GetComponent<BasePokemon> ().pokemonStats.attackStat + "\n" +
			"Defence: " + Pokemon.GetComponent<BasePokemon> ().pokemonStats.defenceStat + "\n" +
			"Sp.Attack: " + Pokemon.GetComponent<BasePokemon> ().pokemonStats.spAttackStat + "\n" +
			"Sp.Defence: " + Pokemon.GetComponent<BasePokemon> ().pokemonStats.spDefenceStat + "\n" +
			"speed: " + Pokemon.GetComponent<BasePokemon> ().pokemonStats.speedStat;

	}
}
