using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstPokemonConfirmButton : MonoBehaviour {


	public OwnedPokemon ownedPokemon;
	public PokemonMoves moves;
	public GameObject player;
	public GameObject pokemon;
	public Button backButton;

	private string pokemonName;
	Button confirmButton;




	void Awake()
	{
		player = GameObject.Find ("Player");
		pokemon = GameObject.FindGameObjectWithTag ("pokemon");

		if (player.GetComponent<Player> ().ownedPokemon.Count != 0) {
			gameObject.SetActive (false);
		}
	}

	// Use this for initialization
	void Start () {

		pokemonName = GameObject.Find ("PokemonName").GetComponent<Text> ().text.ToString();
		confirmButton = gameObject.GetComponent<Button> ();
		confirmButton.onClick.AddListener (TaskOnClick);

	}
	

	void TaskOnClick () {

		moves.Name = "Tackle";
		moves.Category = MoveType.Physical;
		moves.moveType = PokemonType.Normal;
		moves.moveStat.minimum = 30;
		moves.moveStat.maximum = 40;
		moves.accuracy = 95;
		moves.PP = 35;
		moves.power = 35;
		moves.currentPP = 35;

		ownedPokemon.NickName = pokemonName;
		ownedPokemon.ownedPokemon = GameObject.FindGameObjectWithTag ("pokemon").GetComponent<BasePokemon> ();
		ownedPokemon.level = GameObject.FindGameObjectWithTag ("pokemon").GetComponent<BasePokemon> ().level;
		ownedPokemon.moves.Add (moves);


		player.GetComponent<Player> ().ownedPokemon.Add (ownedPokemon);
		pokemon.transform.parent = player.transform;

		backButton.onClick.Invoke ();

		PlayerPrefs.SetString ("ChosenPokemon", ownedPokemon.NickName);

	}
}
