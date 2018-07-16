using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerBottomHouseStairs : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c)
	{
		
			SceneManager.LoadScene ("PlayerHouseTop");

	}
}
