using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarpetCollider : MonoBehaviour {

	public GameObject player;
	public AudioClip gameAudio;

	private GameObject imageBetweenScenes;

	void OnLevelWasLoaded()
	{
		imageBetweenScenes = player.transform.Find ("Main Camera/ImageBetweenScenes").gameObject;
	}


	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update(){
		if (player.GetComponent<BoxCollider2D> ().IsTouching (gameObject.GetComponent<BoxCollider2D> ()) && (player.GetComponent<SpriteRenderer> ().sprite.name == "South_0" ||player.GetComponent<SpriteRenderer> ().sprite.name == "South_1" ||player.GetComponent<SpriteRenderer> ().sprite.name == "South_2")) {
			string currentScene = SceneManager.GetActiveScene ().name;
			PlayerPrefs.SetString ("LastScene", currentScene);
			PlayerPrefs.Save ();

			switch (currentScene) {
			case "PlayerHouseBottom":
				player.GetComponent<PlayerMovement> ().isAllowedToMove = false;
				imageBetweenScenes.SetActive (true);
				break;

			case "GarysHouse":
				player.GetComponent<PlayerMovement> ().isAllowedToMove = false;
				imageBetweenScenes.SetActive (true);
				break;

			case "OakLab":
				PlayMusic (gameAudio);      
				player.GetComponent<PlayerMovement> ().isAllowedToMove = false;
				imageBetweenScenes.SetActive (true);
				break;

			default:
				break;

			}
			SceneManager.LoadScene ("MainGame");

		}

	}

	void PlayMusic (AudioClip name)
	{
		GameObject.Find ("BgAudio").GetComponent<AudioSource> ().clip = name;
		GameObject.Find ("BgAudio").GetComponent<AudioSource> ().Play ();
	}
	
}
