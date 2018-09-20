using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarpetCollider : MonoBehaviour {

	public GameObject player;
	public AudioClip gameAudio;


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
				break;

			case "GarysHouse":
				break;

			case "OakLab":
				//PlayMusic (gameAudio);      //uncomment to change audio as scene shifts from oakLab to MainGame
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
