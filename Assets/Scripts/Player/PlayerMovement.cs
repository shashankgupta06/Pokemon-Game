using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Direction currentDir;
	Vector2 input;
	bool isMoving = false;
	Vector3 startPos;
	Vector3 endPos;
	float t;

	public Sprite northSprite;
	public Sprite southSprite;
	public Sprite eastSprite;
	public Sprite westSprite;

	public float walkSpeed = 3f;


	public bool isAllowedToMove = true;


	GameObject[] trees;

	void Start()
	{
		trees = GameObject.FindGameObjectsWithTag ("Tree");
		isAllowedToMove = true;
	}


	// Update is called once per frame
	void Update () {

		if (!isMoving && isAllowedToMove) {
			input = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));

			if (Mathf.Abs (input.x) > Mathf.Abs(input.y)) {
				input.y = 0;
			} else {
				input.x = 0;
			}

			if (input != Vector2.zero)                      //cleanup required!
			{

				if (input.x < 0) 
				{
					currentDir = Direction.West;
				}

				if (input.x > 0) 
				{
					currentDir = Direction.East;
				}

				if (input.y < 0) 
				{
					currentDir = Direction.South;
				}

				if (input.y > 0) 
				{
					currentDir = Direction.North;
				}



				switch (currentDir) 
				{

				case Direction.North:
					gameObject.GetComponent<SpriteRenderer> ().sprite = northSprite;
					break;

				case Direction.South:
					gameObject.GetComponent<SpriteRenderer> ().sprite = southSprite;
					break;
				
				case Direction.East:
					gameObject.GetComponent<SpriteRenderer> ().sprite = eastSprite;
					break;
				
				case Direction.West:
					gameObject.GetComponent<SpriteRenderer> ().sprite = westSprite;
					break;
				


				}

				StartCoroutine (Move(transform));
			}
			
		}
	



	}


	public IEnumerator Move(Transform entity)
	{

		isMoving = true;
		startPos = entity.position;
		t = 0;
		endPos = new Vector3 (startPos.x + System.Math.Sign (input.x), startPos.y + System.Math.Sign (input.y), startPos.z);


		foreach (GameObject tree in trees) {

			if (gameObject.GetComponent<BoxCollider2D> ().IsTouching (tree.GetComponent<BoxCollider2D> ())) {         //solution to colliders?
				entity.position = startPos;


			} else {
				while (t < 1f) {
					t += Time.deltaTime * walkSpeed;
					entity.position = Vector3.Lerp (startPos, endPos, t);
					yield return null;

				}


			}
		}
			isMoving = false;
			yield return 0;
		}
		


}



enum Direction
{
	North,
	South,
	East,
	West
}