using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private float dirX, dirY, speed;
    private Rigidbody2D rbPlayer;
    
	public bool ClimbingAllowed{ get; set; }

    // Start is called before the first frame update
    private void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
		speed = 10.0f;
    }

    // Update is called once per frame
    private void Update()
    {
		dirX = Input.GetAxisRaw("Horizontal") * speed;
        //rbPlayer.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rbPlayer.velocity.y);

        //if (Input.GetKey(KeyCode.Space))
        //  rbPlayer.velocity = new Vector2(0, 7);
		
		if (ClimbingAllowed)
		{
			dirY = Input.GetAxisRaw("Vertical") * speed;
			//rbPlayer.velocity = new Vector2(Input.GetAxis("Vertical") * speed, rbPlayer.velocity.y);
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

		if (Input.GetKey(KeyCode.Space))
           rbPlayer.velocity = new Vector2(0, 7);
		
	
	}




}
