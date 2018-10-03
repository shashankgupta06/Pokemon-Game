using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MenuSaveButton : MonoBehaviour {

	public Button saveButton;
	public GameObject player;


	void Awake(){
		player = GameObject.Find ("Player");
		saveButton = gameObject.GetComponent<Button> ();

	}

	void Start()
	{
		player.transform.Find ("Main Camera/Menu").gameObject.SetActive (false);
		saveButton.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () {
		
		Save ();
		Debug.Log ("GAME SAVED");
		Debug.Log (player.transform.position.x);
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd");
		PlayerData data = new PlayerData ();

		data.positionX = player.transform.position.x;
		data.positionY = player.transform.position.y;
		data.audio = GameObject.Find ("BgAudio").gameObject.GetComponent<AudioSource> ().clip.name;
		data.sprite = player.GetComponent<SpriteRenderer> ().sprite.name;

		bf.Serialize (file, data);
		file.Close ();
	}
}
