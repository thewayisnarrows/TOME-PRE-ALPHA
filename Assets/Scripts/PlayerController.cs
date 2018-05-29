using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    private float currentMoveSpeed;
    private Animator animator;
    private bool playerMoving;
    private Vector2 lastMove;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f)
        {
            MoveCharacter("Horizontal");
        }

        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
        {
            MoveCharacter("Vertical");
        }

        // Face toward mouse
        LookAtMouse();
        
        // update characters animations with effects from movecharacter and lookatmouse
        UpdateAnimation();
    }

    private void LookAtMouse()
    {
        Vector3 characterPostion = Camera.main.WorldToScreenPoint(transform.position);

        lastMove = new Vector2(Input.mousePosition.x - characterPostion.x, Input.mousePosition.y - characterPostion.y);
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
        float moveAmount = Input.GetAxisRaw(axis);
        float velocity = moveAmount * moveSpeed * Time.deltaTime;

        transform.Translate(new Vector3(axis.Equals("Horizontal") ? velocity : 0f, axis.Equals("Vertical") ? velocity : 0f, 0f));

        playerMoving = true;
        lastMove = new Vector2(axis.Equals("Horizontal") ? moveAmount : 0f, axis.Equals("Vertical") ? moveAmount : 0f);

        // currently unused
        //currentMoveSpeed = (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f) ? moveSpeed / 2f : moveSpeed;
    }
}