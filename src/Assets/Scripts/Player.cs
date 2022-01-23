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
	
	//falling 
	private bool isFalling = false;
	private bool allowed = true;
	private static float posPoint;
	private int random = 0;
	private int max = 1;
	
	
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
        
        //climbing
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
		
		//jumping
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


		//falling
		if (isFalling)
		{
			switch (posPoint)
			{
				case < (-70): max = 1; break;
				case < (-60): max = 2; break;
				case < (-50): max = 3; break;
				case < (-40): max = 5; break;
				case < (-30): max = 6; break;
				case < (-20): max = 7; break;
				default: max = 8; break;
			}
			
			int[] array = new int[]{4, 11, 18, 25, 32, 39, 46, 53};	//falls max 8 floors
			if (allowed)
			{
				random = Random.Range(0, max);
				allowed = false;
			}
			int diff = array[random];
			
			if (transform.position.y < (posPoint - diff))
			{
			     bcPlayer.isTrigger = false;
			     isFalling = false;
			     allowed = true;
			}
		}
		
		
		
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

     private void OnCollisionEnter2D(Collision2D other)
     {
	     if (other.gameObject.tag == "Enemy")
	     {
		     bcPlayer.isTrigger = true;
		     isFalling = true;
		     posPoint = other.gameObject.transform.position.y;

	     }
	     
     }
     
   

}
