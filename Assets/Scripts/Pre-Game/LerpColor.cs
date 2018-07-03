using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpColor : MonoBehaviour {

	public Image image;
	public Text OakText;
	public Text PrompText;

	public Color color1 = Color.black;
	public Color color2 = Color.white;


	public void Start()
	{
		image = gameObject.GetComponent<Image> ();

	}


	public void Update()
	{

		image.color = Color.Lerp (color1, color2, Mathf.PingPong(Time.time,10f));
		if (image.color == color1) {
			OakText.enabled = true;
			PrompText.enabled = true;
		}
	}


}
