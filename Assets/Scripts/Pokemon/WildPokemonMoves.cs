using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildPokemonMoves : MonoBehaviour {

	//public List<WildPokemon> wildPokemonMoves = new List<WildPokemon>(4);
	public WildPokemon wildMoves = new WildPokemon();     //creates a gameObject of class WildPokemon
	private PokemonMoves move;                            // a move
	//public string pokemonName;

	private GameManager gm;

	private int moveAdded = 0;              //counter to make sure one move is added to the wild pokemon



	void Update () {
		gm = FindObjectOfType<GameManager>();       
		//Debug.Log (gm.allMoves [0].Name );   //debugs the move addded
		move = gm.allMoves [0];                     // move added from GameManager


		if (moveAdded == 0) {

			wildMoves.moves.Add (gm.allMoves [0]);                               // adds a move from allMoves in the GM  

			//wildPokemonMoves [0] = new WildPokemon ();          //added the move to the WildPokemon class!
			//wildPokemonMoves[0].moves.Add(gm.allMoves[0]);
			//gameObject.GetComponent<WildPokemonMoves>().wildPokemonMoves.Add(wildMoves);
		}

		moveAdded = 1;                  //makes sure we do not keep adding the move!

		//tackle.moves.Add (gm.allMoves [0]);
/*		pokemonName = gameObject.GetComponent<BasePokemon> ().PName;


		switch (pokemonName) {


		case "Bulbasaur":
			break;

		case "Squirtle":
			Debug.Log ("Squirtle");

			break;

		case "Venasaur":
			Debug.Log ("Venasaur");
			break;

		default:
			break;



		}*/


	}


}



[System.Serializable]
public class WildPokemon
{
	public List<PokemonMoves> moves = new List<PokemonMoves> ();
}
