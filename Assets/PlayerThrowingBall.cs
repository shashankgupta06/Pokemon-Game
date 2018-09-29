using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowingBall : MonoBehaviour {

	public bool move = false;
	public GameObject pokemon;


	// Update is called once per frame
	void Update () {



		if (move == true) {
			gameObject.transform.Translate (Vector2.left * (Time.deltaTime * 2));
		}

		if (gameObject.GetComponent<RectTransform> ().offsetMax.x <= -4) {
			pokemon = GameObject.Find ("Battle/AttackPodium/emptyPoke(Clone)");
			pokemon.SetActive (true);
			move = false;
		}
		
	}
}
