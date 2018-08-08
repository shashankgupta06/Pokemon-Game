using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {


	private static DontDestroy instance;


	// Use this for initialization
	void Awake()
	{

		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		} else if(instance != this) {
			Destroy (gameObject);
		}
	}
}
