using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarpetCollider : MonoBehaviour {

	public GameObject player;

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.name == "player" && player.GetComponent<SpriteRenderer> ().sprite.name == "South_0") 
		{
			SceneManager.LoadScene ("main");

		}


	}
}
