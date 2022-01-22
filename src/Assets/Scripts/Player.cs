using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private float dirX, dirY;
	public float speed = 10.0f;
	public float velocity = 20.0f;
	public float gravity = 6.0f;
    private Rigidbody2D rbPlayer;
    private CapsuleCollider2D bcPlayer;
    public float groundCheckDistance = 0.01f;
    public LayerMask groundLayerMask;

    // animations
    private Animator anim;
    private bool mHeadingRight = true;
    
	public bool ClimbingAllowed{ get; set; }

	
	
    // Start is called before the first frame update
    private void Start()
    {
	    anim = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody2D>();
	    bcPlayer = GetComponent<CapsuleCollider2D>();
    }

    
    
    // Update is called once per frame
    private void Update()
    {
		dirX = Input.GetAxisRaw("Horizontal") * speed;
		
        // for running animation
        if (dirX == 0)
        {
	        anim.SetBool("IsRunning", false);
        }
        else
        {
	        anim.SetBool("IsRunning", true);
        }
        
        rbPlayer.gravityScale = gravity;
        bool isClimb = false;
		if (ClimbingAllowed)
		{
			anim.SetBool("IsOnLadder", true);
			isClimb = true;
			dirY = Input.GetAxisRaw("Vertical") * speed;
			if (dirY == 0)
			{
				anim.SetBool("IsClimbing", false);
			}
			else
			{
				anim.SetBool("IsClimbing", true);
			}
		}
		else
		{
			anim.SetBool("IsOnLadder", false);
			anim.SetBool("IsClimbing", false);
		}
		
		
		var jumpMovement = Input.GetKeyDown(KeyCode.Space);
		var onGround = IsOnGround();
		
		if (onGround || isClimb)
		{
			anim.SetBool("IsFalling", false);
			anim.SetBool("IsJumping", false);
		}
		else
		{
			anim.SetBool("IsJumping", true);
			anim.SetBool("IsFalling", true);
		}

		
		if (jumpMovement && onGround)
			rbPlayer.velocity= new Vector2(0, velocity);
		

    }
    
    

 	private void FixedUpdate()
    {
	    
	    if (ClimbingAllowed)
		{
			rbPlayer.isKinematic = true;
			rbPlayer.velocity = new Vector2(dirX,dirY);
		}
		else
		{
			rbPlayer.isKinematic = false;
			rbPlayer.velocity = new Vector2(dirX, rbPlayer.velocity.y);
		}
		

		// move right
		if (dirX > 0 && !mHeadingRight)
		{
			transform.localRotation *= Quaternion.Euler(0, 180, 0);
			mHeadingRight = true;
		}
		// move left
		else if (dirX < 0 && mHeadingRight)
		{
			transform.localRotation *= Quaternion.Euler(0, 180, 0);
			mHeadingRight = false;
		}
		

    }


    
     bool IsOnGround()
    {
	    // Cast our current BoxCollider in the current gravity direction.
        var hitInfo = Physics2D.BoxCast(
            bcPlayer.bounds.center, bcPlayer.bounds.size, 
            0.0f, Physics2D.gravity.normalized, groundCheckDistance, 
            groundLayerMask);

        return hitInfo.collider != null;
    }
   

}
