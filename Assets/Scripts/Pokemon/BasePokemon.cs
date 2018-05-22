using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePokemon : MonoBehaviour {

	public string Name;
	public Sprite image;
	public BiomeList biomeFound;
	public PokemonType type;
	public float baseHP;
	public Rarity rarity;
	private float maxHealth;
	public float baseAttack;
	public float maxAttack;
	public float baseDefence;
	public float maxDefence;
	public float speed;

	private int level;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}


	public enum Rarity
	{
		veryCommon,
		Common,
		SemiRare,
		Rare,
		VeryRare
	}

	public enum PokemonType
	{
		Flying,
	Ground,
	Rock,
	Steel,
	Fire,
	Water,
	Grass,
	Ice,
	Electro,
	Psychic,
	Dark,
	Dragon


	}



