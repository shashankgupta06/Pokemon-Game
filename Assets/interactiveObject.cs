using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactiveObject : MonoBehaviour
{

	public GameObject player;

	void OnLevelWasLoaded ()
	{
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{

	
		if (player.GetComponent<BoxCollider2D> ().IsTouching (gameObject.GetComponent<BoxCollider2D> ())) {
			if (Input.GetKeyDown (KeyCode.Return)) {
				
				player.transform.Find ("Main Camera/PlayerInteraction").gameObject.SetActive (true);

				switch (gameObject.name) {

				case "Clock":
					string sysHour = System.DateTime.UtcNow.ToLocalTime ().ToString ();
					player.transform.Find ("Main Camera/PlayerInteraction/Interaction/Text").gameObject.GetComponent<Text> ().text = sysHour;
					break;

				default:
					break;




				}
			}
		} else {
			player.transform.Find ("Main Camera/PlayerInteraction").gameObject.SetActive (false);
		}



	}
}
