using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    private float currentMoveSpeed;
    private Animator animator;
    private Rigidbody2D playerRigidbody;
    private bool playerMoving;
    private Vector2 lastMove;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        // if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f) <--- Original Code
        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            // MoveCharacter("Horizontal"); <--- Original Code
            playerMoving = true;
            playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, playerRigidbody.velocity.y);
        }

        // if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f) <--- Original Code
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            // MoveCharacter("Vertical"); <--- Original Code
            playerMoving = true;
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
        }

        
       if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
       {
           playerRigidbody.velocity = new Vector2(0f, playerRigidbody.velocity.y);
       }
       
       if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
       {
           playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
       }

        // Face toward mouse
        LookAtMouse();
        
        // update characters animations with effects from movecharacter and lookatmouse
        UpdateAnimation();
    }

    private void LookAtMouse()
    {
        Vector3 characterPosition = Camera.main.WorldToScreenPoint(transform.position);

        lastMove = new Vector2(Input.mousePosition.x - characterPosition.x, Input.mousePosition.y - characterPosition.y);
    }

    private void UpdateAnimation()
    {
        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        animator.SetBool("PlayerMoving", playerMoving);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);
    }

    private void MoveCharacter(string axis)
    {
        // currently unused
        //currentMoveSpeed = (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f) ? moveSpeed / 1.5f : moveSpeed;

        // https://www.youtube.com/watch?v=ZriXzQWjnmI
        //float movementInputX = Input.GetAxisRaw("Horizontal");
        //float movementInputY = Input.GetAxisRaw("Vertical");

        //Vector2 direction = new Vector2(movementInputX, movementInputY);
        //direction.Normalize();
        //direction *= moveSpeed;

        float moveAmount = Input.GetAxisRaw(axis);
        float velocity = moveAmount * moveSpeed * Time.deltaTime;

        transform.Translate(new Vector3(axis.Equals("Horizontal") ? velocity : 0f, axis.Equals("Vertical") ? velocity : 0f, 0f));

        playerMoving = true;
        lastMove = new Vector2(axis.Equals("Horizontal") ? moveAmount : 0f, axis.Equals("Vertical") ? moveAmount : 0f);

        
    }
}