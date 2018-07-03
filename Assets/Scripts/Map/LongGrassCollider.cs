using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongGrassCollider : MonoBehaviour {

	public Sprite Enter;
	public Sprite Exit;



	// Use this for initialization
	void OnTriggerEnter2D(Collider2D c)
	{
		gameObject.GetComponent<SpriteRenderer> ().sprite = Enter;

	}

	void OnTriggerExit2D(Collider2D c)
	{

		gameObject.GetComponent<SpriteRenderer> ().sprite = Exit;

	}
}
