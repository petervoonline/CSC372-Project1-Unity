using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class is to implement the player movement left, right, jump. 
*/
public class PlayerMovement : MonoBehaviour
{

    //private fields required to implement
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;
    private float dirX=0f;
    private SpriteRenderer sprite;
    //player speed and jumpForce(gravity) can be modified by Unity IDE
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpForce = 14f;
    //There is movement state of idle (stop), running, jumping, and falling
    private enum MovementState { idle, running, jumping, falling }

   
    /*
    This method is called to instantiate the objects.
    It is called before the first frame update
    */
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //dirX is horizontal direction
        dirX = Input.GetAxisRaw("Horizontal");
        //velocity is the player's speed when moving
        rb.velocity = new Vector2(dirX * moveSpeed,rb.velocity.y);
        //if player is not on the ground, or jumping, velocity is changing by its position
        if (Input.GetButtonDown("Jump") && IsGrounded()) 
        { 
           rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        //Initialize the current state out of 4 states.
        MovementState state;
        //if horizonally moving right, player face towards to right
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;

        }//else if player moving left, player face towards to left
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }//else player stays the same
        else
        {
            state = MovementState.idle;
        }
        //if vertical velocity is increasing it means jumping
        if(rb.velocity.y > .1f) //then we know it's jumping
        {
            state = MovementState.jumping;
        }//if vertical velocity is decreasing, it means falling
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int) state);
    }
    /*
    Helper function to indicate whether it's on the ground or not
    */
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
