using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


	public GameObject playerCamera;
	public GameObject battleCamera;


	// Use this for initialization
	void Start () {
		playerCamera.SetActive (true);
		battleCamera.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void EnterBattle(Rarity rarity)
	{
		playerCamera.SetActive (false);
		battleCamera.SetActive (true);

	}
}
