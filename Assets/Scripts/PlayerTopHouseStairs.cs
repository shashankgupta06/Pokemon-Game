﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTopHouseStairs : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.name == "player") 
		{
			SceneManager.LoadScene ("PlayerHouseBottom");
		}


	}
}