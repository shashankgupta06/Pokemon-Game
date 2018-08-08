using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstPokemonBackButton : MonoBehaviour {

	private string pokemonName;


	void Start()
	{

		pokemonName = GameObject.Find ("PokemonName").GetComponent<Text> ().text.ToString();
		Debug.Log (pokemonName);


		Button backButton = gameObject.GetComponent<Button> ();

		backButton.onClick.AddListener (TaskOnClick);


	}

	// Update is called once per frame
	void TaskOnClick () {
		string currentScene = SceneManager.GetActiveScene ().name;
		PlayerPrefs.SetString ("LastScene", currentScene);
		PlayerPrefs.SetString ("PokemonOption", pokemonName);
		PlayerPrefs.Save ();

		SceneManager.LoadScene ("OakLab");
	}
}
