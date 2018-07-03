using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour {

	public Text text;
	
	// Update is called once per frame
	void Start () {
		StartCoroutine (Blink (1));
	}


	private IEnumerator Blink(float waitTime)
	{

		while (true) {
			yield return new WaitForSeconds (waitTime);
			text.enabled = false;
			yield return new WaitForSeconds (waitTime);
			text.enabled = true;
		}
	}
}
