using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerPositioning : MonoBehaviour {


	public GameObject player;
	string LastScene;
	string currentScene;


	public static playerPositioning instance;


	// Use this for initialization
	void Awake()
	{

		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		} else if (instance != this) 
		{
			Destroy (gameObject);
		}
		player = GameObject.Find ("Player");
		player.transform.position = new Vector3 (0, 1, 0);
	}


	void OnLevelWasLoaded(){

		player = GameObject.Find ("Player");
		LastScene = PlayerPrefs.GetString ("LastScene", "");
		currentScene = SceneManager.GetActiveScene ().name;
		Debug.Log (currentScene);


		switch (currentScene) 
		{
		case "OakLab":
			Debug.Log ("Success");
			//player.transform.position = new Vector3 (0, 1, 0);
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

	void Update() {

		int x = 0;

		if (player.transform.position.y < 0 && SceneManager.GetActiveScene().name=="OakLab" && x==0) {
			player.transform.position = new Vector3 (0, 1, 0);
			x++;
		}


	}


}
