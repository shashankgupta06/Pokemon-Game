using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OakLabPlayerPositioning : MonoBehaviour {


	public Sprite northSprite;

	private string LastScene;
	private string currentScene;
	private string pokemonName;

	public GameObject player;


	void Awake()
	{

		player = GameObject.FindGameObjectWithTag ("Player");

		LastScene = PlayerPrefs.GetString ("LastScene", "");
		currentScene = SceneManager.GetActiveScene ().name;
		Debug.Log (currentScene);
		switch (currentScene) 
		{
		case "OakLab":
			Debug.Log ("Success");
			GameObject.FindGameObjectWithTag ("Player").transform.position = new Vector3 (0, 1, 0);
			//Time.timeScale = 0;
			break;

		case "MainGame":
			Debug.Log ("player");
			player.transform.position = new Vector3 (4, -32, 0);
			//Time.timeScale = 0;
			break;

		default:
			break;


		}



		}



}
