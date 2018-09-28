using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTopHouseStairs : MonoBehaviour {
	public GameObject player;


	void Awake()
	{
		player = GameObject.Find ("Player"); 
	}

	void OnLevelWasLoaded()
	{
		player = GameObject.Find ("Player"); 
	}


	void OnTriggerEnter2D(Collider2D c)
	{
			
		     string currentScene = SceneManager.GetActiveScene ().name;
		     PlayerPrefs.SetString ("LastScene", currentScene);
		     PlayerPrefs.Save ();
			 player.GetComponent<PlayerMovement> ().isAllowedToMove = false;
			 SceneManager.LoadScene ("PlayerHouseBottom");

	}
}
