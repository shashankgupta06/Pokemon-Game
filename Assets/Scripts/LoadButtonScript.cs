using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadButtonScript : MonoBehaviour {

	public Button loadButton;

	// Use this for initialization
	void Start () {
		loadButton.onClick.AddListener (Clicked);
	}
	
	// Update is called once per frame
	void Clicked () {
		Debug.Log ("Feature not available at the moment");
	}
}
