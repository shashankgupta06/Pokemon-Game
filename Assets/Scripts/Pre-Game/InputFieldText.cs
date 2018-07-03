using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputFieldText : MonoBehaviour {

	public InputField mainInputField;
	public Text QuestionText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.Return) && mainInputField.text.Length != 0) {
			PlayerPrefs.SetString ("PlayerName", mainInputField.text);
			Debug.Log (mainInputField.text);
			SceneManager.LoadScene ("OakWalkThrough");
		} else if(Input.GetKeyDown (KeyCode.Return) && mainInputField.text.Length == 0){
			Debug.Log ("Name Required");
		}

	}
}
