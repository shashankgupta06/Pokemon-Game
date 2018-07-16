using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerBottomHouseStairs : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c)
	{

		string currentScene = SceneManager.GetActiveScene ().name;
		PlayerPrefs.SetString ("LastScene", currentScene);
		PlayerPrefs.Save ();

		SceneManager.LoadScene ("PlayerHouseTop");

	}
}
