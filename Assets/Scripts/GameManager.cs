using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


	public GameObject playerCamera;
	public GameObject battleCamera;

	public GameObject player;

	public List<BasePokemon> allPokemon = new List<BasePokemon>();
	public List<PokemonMoves> allMoves = new List<PokemonMoves>();

	public Transform defencePodium;
	public Transform attackPodium;
	public GameObject emptyPoke;

	public BattleManager bm;

	public Text type;
	public Text PP;
	public Text pokemonName;
	public Text levelText;
	public Text updateText;


	// Use this for initialization
	void Start () {
		playerCamera.SetActive (true);
		battleCamera.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void EnterBattle(Rarity rarity)
	{
		playerCamera.SetActive (false);
		battleCamera.SetActive (true);

		BasePokemon battlePokemon = GetRandomPokemonFromList (GetPokemonByRarity (rarity));

        //TODO: Add another way to prevent the player for perfoming input while in battle screen.
		//player.GetComponent<PlayerMovement>().isAllowedToMove = false;

		GameObject dPoke = Instantiate (emptyPoke, defencePodium.transform.position, Quaternion.identity) as GameObject;

		Vector3 pokeLocalPos = new Vector3 (0, 1, 0);

		dPoke.transform.parent = defencePodium;
		dPoke.transform.localPosition = pokeLocalPos;
		BasePokemon tempPoke = dPoke.AddComponent<BasePokemon> () as BasePokemon;
		tempPoke.AddMember (battlePokemon); 

		dPoke.GetComponent<SpriteRenderer> ().sprite = battlePokemon.image;
		updateText.text ="A wild "+ dPoke.GetComponent<BasePokemon>().PName+ " appeared!";

		GameObject ownedPoke = Instantiate (emptyPoke, attackPodium.transform.position, Quaternion.identity) as GameObject;
		Vector3 OwnedPokeLocalPos = new Vector3 (0, 1, 0);


		ownedPoke.transform.parent = attackPodium;
		ownedPoke.transform.localPosition = OwnedPokeLocalPos;
		ownedPoke.transform.Rotate (0, 180, 0);
		BasePokemon ownedPokemon = ownedPoke.AddComponent<BasePokemon> () as BasePokemon;
		ownedPokemon.AddMember (player.GetComponent<Player> ().ownedPokemon [0].ownedPokemon);

		ownedPoke.GetComponent<SpriteRenderer> ().sprite = ownedPokemon.image;
		type.text = player.GetComponent<Player> ().ownedPokemon [0].moves [0].Category.ToString ();
		PP.text = player.GetComponent<Player> ().ownedPokemon [0].moves [0].PP.ToString();          //eventually move this all to BattleManager?
		pokemonName.text = player.GetComponent<Player>().ownedPokemon[0].NickName;
		levelText.text = player.GetComponent<Player> ().ownedPokemon [0].level.ToString();

		bm.ChangeMenu (BattleManager.BattleMenu.Selection);
	}

	public List<BasePokemon> GetPokemonByRarity(Rarity rarity)
	{
		List<BasePokemon> returnPokemon = new List<BasePokemon> ();
		foreach (BasePokemon Pokemon in allPokemon) 
		{
			if (Pokemon.rarity == rarity)
				returnPokemon.Add (Pokemon);
		}

		return returnPokemon;
	}

	public BasePokemon GetRandomPokemonFromList (List<BasePokemon> pokeList)
	{
		BasePokemon poke = new BasePokemon ();
		int pokeIndex = Random.Range (0, pokeList.Count - 1);
		poke = pokeList [pokeIndex];
		return poke;

	}
}


[System.Serializable]
public class PokemonMoves
{

	public string Name;
	public MoveType Category;
	public Stat moveStat;
	public PokemonType moveType;
	public int PP;
	public float power;
	public float accuracy;
}

[System.Serializable]
public class Stat
{

	public float minimum;
	public float maximum;

}

public enum MoveType
{
	Physical,
	Special,
	Status


}
