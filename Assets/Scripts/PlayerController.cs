using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float diagonalMoveModifier;

    private float currentMoveSpeed;
    private Animator animator;
    private Rigidbody2D playerRigidbody;
    private bool playerMoving;
    private Vector2 lastMove;


    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;


    private DamageManager damageManager = new DamageManager();


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

        if (!attacking)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f)
            {
                MoveCharacter("Horizontal");
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                MoveCharacter("Vertical");
            }

            // if player is standing still stop movement
            StandingStillCheck();

            // Face toward mouse
            LookAtMouse();

            // update characters animations with effects from movecharacter and lookatmouse
            UpdateAnimation();

            if (Input.GetKey(KeyCode.Mouse0))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                playerRigidbody.velocity = Vector2.zero;
                animator.SetBool("Attack", true);
            }

        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }
        else
        {
            attacking = false;
            animator.SetBool("Attack", false);
        }
    }


    /// <summary>
    /// Moves the character across a certain plane
    /// </summary>
    /// <param name="axis">"Horizontal" or "Vertical"</param>
    private void MoveCharacter(string axis)
    {
        currentMoveSpeed = CalculateMoveSpeed();

        playerMoving = true;
        float velocityDelta = Input.GetAxisRaw(axis) * currentMoveSpeed;

        playerRigidbody.velocity = new Vector2(
            axis.Equals("Horizontal") ? velocityDelta : playerRigidbody.velocity.x,
            axis.Equals("Vertical") ? velocityDelta : playerRigidbody.velocity.y);

    }

    /// <summary>
    /// Sets velocity on the playerRigidbody object when player is not moving on the Horzontal or Veritcal Axis
    /// </summary>
    private void StandingStillCheck()
    {
        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            playerRigidbody.velocity = new Vector2(0f, playerRigidbody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
        }
    }

    /// <summary>
    /// Turns Character to face towards mouse
    /// </summary>
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

    /// <summary>
    /// Calculates current movespeed to compensate for diagonal movement
    /// </summary>
    /// <returns>adjusted move speed</returns>
    private float CalculateMoveSpeed()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f
                    && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
        {
            return moveSpeed * diagonalMoveModifier;
        }
        else
        {
            return moveSpeed;
        }
    }
}