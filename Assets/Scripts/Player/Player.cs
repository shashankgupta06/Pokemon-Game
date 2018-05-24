using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public List<OwnedPokemon> ownedPokemon = new List<OwnedPokemon>();



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}


[System.Serializable]
public class OwnedPokemon
{
	public string NickName;
	public BasePokemon ownedPokemon;
	public int level;
	public List<PokemonMoves> moves = new List<PokemonMoves> ();
}
