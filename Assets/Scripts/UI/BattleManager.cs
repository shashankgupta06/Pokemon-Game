using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

	public BattleMenu currentMenu;
	public GameObject player;


	[Header("Cameras")]
	public GameObject battleCamera;
	public GameObject mainCamera;

	[Header("Selection")]
	public GameObject SelectionMenu;
	public GameObject SelectionInfo;
	public Text selectionInfoText;
	public Text fight;
	private string fightT;
	public Text bag;
	private string bagT;
	public Text pokemon;
	private string pokemonT;
	public Text run;
	private string runT;



	[Header("Moves")]
	public GameObject movesMenu;
	public GameObject movesDetails;
	public Text PP;
	public Text PType;
	public Text moveO;
	private string moveOT;
	public Text moveT;
	private  string moveTT;
	public Text moveTH;
	private string moveTHT;
	public Text moveF;
	private string moveFT;

	[Header("Info")]
	public GameObject InfoMenu;
	public Text infoText;

	[Header("Misc")]
	public int currentSelection;


	//public Text PokemonName;


	void Awake()
	{
		player = GameObject.Find ("Player");
		mainCamera = GameObject.Find ("Main Camera");

	}


	// Use this for initialization
	void Start () {
		fightT = fight.text;
		bagT = bag.text;
		pokemonT = pokemon.text;
		runT = run.text;
		moveOT = moveO.text;
		moveTT = moveT.text;
		moveTHT = moveTH.text;
		moveFT = moveF.text;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			if (currentSelection < 4){
				currentSelection++;
			}
		}

		if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			
			if (currentSelection > 0) {
				currentSelection--;
			}
		}

		if (currentSelection == 0) {
			currentSelection = 1; 
		}

		if (currentSelection == 1 && Input.GetKeyDown (KeyCode.Return)) 
		{
			Debug.Log ("FIGHT SELECTED");
			ChangeMenu (BattleMenu.Fight);
		}

		if (currentSelection == 4 && Input.GetKeyDown (KeyCode.Return)) 
		{
			Debug.Log ("RUN SELECTED");
			battleCamera.SetActive (false);
			mainCamera.SetActive (true);
			player.GetComponent<PlayerMovement> ().isAllowedToMove = true;
			Destroy (GameObject.Find ("DefencePodium/emptyPoke(Clone)"));
			Destroy (GameObject.Find ("AttackPodium/emptyPoke(Clone)"));
		}

		if (currentMenu == BattleMenu.Fight && Input.GetKeyDown (KeyCode.Backspace)) 
		{
			ChangeMenu (BattleMenu.Selection);
		}


		switch (currentMenu) 
		{
		case BattleMenu.Fight:
			switch (currentSelection) 
			{
			case 1:
				moveO.text = "> " + player.GetComponent<Player>().ownedPokemon[0].moves[0].Name;
				moveT.text =  moveTT;
				moveTH.text =  moveTHT;
				moveF.text = moveFT;
				 break;

			case 2:
				moveO.text =  player.GetComponent<Player>().ownedPokemon[0].moves[0].Name;
				moveT.text = "> " +moveTT;
				moveTH.text =  moveTHT;
				moveF.text = moveFT;
				break;

			case 3:
				moveO.text =  player.GetComponent<Player>().ownedPokemon[0].moves[0].Name;
				moveT.text =  moveTT;
				moveTH.text = "> " + moveTHT;
				moveF.text = moveFT;
				break;

			case 4:
				moveO.text =  player.GetComponent<Player>().ownedPokemon[0].moves[0].Name;
				moveT.text =  moveTT;
				moveTH.text =  moveTHT;
				moveF.text = "> " +moveFT;
				break;

			}
			break;

		case BattleMenu.Selection:
			
			switch (currentSelection) 
			{
			case 1:
				fight.text = "> " + fightT;
				bag.text = bagT;
				pokemon.text = pokemonT;
				run.text = runT;
				break;

			case 2:
				fight.text = fightT;
				bag.text ="> " + bagT;
				pokemon.text = pokemonT;
				run.text = runT;
				break;

			case 3:
				fight.text = fightT;
				bag.text = bagT;
				pokemon.text = "> " + pokemonT;
				run.text = runT;
				break;

			case 4:
				fight.text =  fightT;
				bag.text = bagT;
				pokemon.text = pokemonT;
				run.text = "> " +runT;
				break;

			}
			break;

		}

	
	}


	public void ChangeMenu(BattleMenu m)
	{	
		currentMenu = m;
		currentSelection = 0;
		switch (m) 
		{
		case BattleMenu.Selection:
			SelectionMenu.gameObject.SetActive (true);
			SelectionInfo.gameObject.SetActive (true);
			movesMenu.gameObject.SetActive (false);
			movesDetails.gameObject.SetActive (false);
			InfoMenu.gameObject.SetActive (false);
			break;

		case BattleMenu.Fight: 
			SelectionMenu.gameObject.SetActive (false);
			SelectionInfo.gameObject.SetActive (false);
			movesMenu.gameObject.SetActive (true);
			movesDetails.gameObject.SetActive (true);
			InfoMenu.gameObject.SetActive (false);
			break;

		case BattleMenu.Info: 
			SelectionMenu.gameObject.SetActive (false);
			SelectionInfo.gameObject.SetActive (false);
			movesMenu.gameObject.SetActive (false);
			movesDetails.gameObject.SetActive (false);
			InfoMenu.gameObject.SetActive (true);
			break;

		/*case BattleMenu.Selection: 

			break;

		case BattleMenu.Selection: 

			break;*/

		}

	}

	public enum BattleMenu
	{
		Selection,
		Pokemon,
		Bag,
		Fight,
		Info


	}
}
