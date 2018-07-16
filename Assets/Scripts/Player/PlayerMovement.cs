using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Sprite northSprite;
    public Sprite southSprite;
    public Sprite eastSprite;
    public Sprite westSprite;
	public Sprite northWalk1;
	public Sprite northWalk2;
	public Sprite southWalk1;
	public Sprite southWalk2;
	public Sprite eastWalk1;
	public Sprite eastWalk2;
	public Sprite westWalk1;
	public Sprite westWalk2;

    public float walkSpeed = 5f;

    /// <summary>
    /// Determine if the player is currently in the moving animation
    /// </summary>
    private bool IsMoving = false;
	private bool Walk = false;
    private SpriteRenderer spriteRender;

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        InputMovement();
    }


    private void InputMovement()
    {

        if (IsMoving) return;

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (input == Vector2.zero) return;


        if (Mathf.Abs(input.x) > Mathf.Abs(input.y)) input.y = 0; else input.x = 0;

        Vector2 dir = input.normalized;

        dir = new Vector2(dir.x / 1, dir.y / 1);

        SwapSpriteByDirection(dir);

        PerformMovement(dir);

    }

    private void SwapSpriteByDirection(Vector2 direction)
    {
		

        if (direction.x > 0)
        {
			if (Walk) {
				spriteRender.sprite = eastWalk1;
				Walk = false;
			} else {
				spriteRender.sprite = eastWalk2;
				Walk = true;
			}
        }
        else if (direction.x < 0)
        {
			if (Walk) {
				spriteRender.sprite = westWalk1;
				Walk = false;
			} else {
				spriteRender.sprite = westWalk2;
				Walk = true;
			}
        }
        else if (direction.y > 0)
        {
			if (Walk) {
				spriteRender.sprite = northWalk1;
				Walk = false;
			} else {
				spriteRender.sprite = northWalk2;
				Walk = true;
			}
        }
        else if (direction.y < 0)
        {
			if (Walk) {
				spriteRender.sprite = southWalk1;
				Walk = false;
			} else {
				spriteRender.sprite = southWalk2;
				Walk = true;
			}
        }
    }

    private void PerformMovement(Vector2 direction)
    {

        // check if the player can even move there

        RaycastHit2D[] ray = Physics2D.RaycastAll(gameObject.transform.position, direction, 1f);           //player moves by 0.5
        bool pathBlocked = ray.Any(i => i.collider.GetComponent<Collidable>() != null);
        if (pathBlocked) return;

        StartCoroutine(MoveAnimation(direction));

    }

    private IEnumerator MoveAnimation(Vector2 direction)
    {
        Vector2 goal = (Vector2)gameObject.transform.position + direction;
        IsMoving = true;
        float t = 0;
        float rate = 1 / 0.3f;
        Vector2 start = gameObject.transform.position;
        while (Vector2.Distance(gameObject.transform.position, goal) > Mathf.Epsilon)
        {
            t += Time.deltaTime * rate;
            gameObject.transform.position = Vector2.MoveTowards(start, goal, t);

            yield return new WaitForFixedUpdate();
        }

	 


        IsMoving = false;

		switch (spriteRender.sprite.name) 
		{

		case "North_1":
			spriteRender.sprite = northSprite;
			break;
		case "North_2":
			spriteRender.sprite = northSprite;
			break;
		
		case "East_1":
			spriteRender.sprite = eastSprite;
			break;
		case "East_2":
			spriteRender.sprite = eastSprite;
			break;

		case "West_1":
			spriteRender.sprite = westSprite;
			break;
		case "West_2":
			spriteRender.sprite = westSprite;
			break;


		case "South_1":
			spriteRender.sprite = southSprite;
			break;
		case "South_2":
			spriteRender.sprite = southSprite;
			break;

		default:
			break;


		}
	

    }
}
