using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour {

	public Button start;

	// Use this for initialization
	void Start () {
		start.onClick.AddListener (Clicked);
	}
	
	// Update is called once per frame
	void Clicked () {

		SceneManager.LoadScene ("Character");


	}
}
