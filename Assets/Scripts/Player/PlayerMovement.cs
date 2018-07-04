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

    public float walkSpeed = 5f;

    /// <summary>
    /// Determine if the player is currently in the moving animation
    /// </summary>
    private bool IsMoving = false;

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

        SwapSpriteByDirection(dir);

        PerformMovement(dir);

    }

    private void SwapSpriteByDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            spriteRender.sprite = eastSprite;
        }
        else if (direction.x <= -1)
        {
            spriteRender.sprite = westSprite;
        }
        else if (direction.y > 0)
        {
            spriteRender.sprite = northSprite;
        }
        else if (direction.y <= -1)
        {
            spriteRender.sprite = southSprite;
        }
    }

    private void PerformMovement(Vector2 direction)
    {

        // check if the player can even move there

        RaycastHit2D[] ray = Physics2D.RaycastAll(gameObject.transform.position, direction, 1);
        bool pathBlocked = ray.Any(i => i.collider.GetComponent<Collidable>() != null);
        if (pathBlocked) return;

        StartCoroutine(MoveAnimation(direction));

    }

    private IEnumerator MoveAnimation(Vector2 direction)
    {
        Vector2 goal = (Vector2)gameObject.transform.position + direction;
        IsMoving = true;

        while (Vector2.Distance(gameObject.transform.position, goal) > Mathf.Epsilon)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, goal, walkSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        IsMoving = false;

    }



}
