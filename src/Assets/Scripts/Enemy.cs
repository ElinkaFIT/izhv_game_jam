using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float agroRange;
    public float enemySpeed = 3;
    private float edgeCheckDistance = 0.00001f;
    private Rigidbody2D rbEnemy;
    private CapsuleCollider2D bcEnemy;
    public LayerMask edgeLayerMask;
    private float direction = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        bcEnemy = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rbEnemy.gravityScale = 10.0f;
        
        //Debug.Log("Enemy position: " + transform.position);
        //Debug.Log("Player position: " + player.position);
       // Debug.Log("Player position: " + player.position.y);
        
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        bool chasingAllowed = (distToPlayer < agroRange && player.position.y < transform.position.y + 1 &&
                               player.position.y > transform.position.y - 1);
        if (chasingAllowed )
        {
            ChasePlayerMode();
        }
        else
        {
            LesuireMode();
        }

    }

    void ChasePlayerMode()
    {
        if (transform.position.x < player.position.x)
            {   // player is to the right
                direction = 1.0f;
            }
        else if (transform.position.x > player.position.x)
            {   // player is to the left
                direction = -1.0f;
            }
        transform.localScale = new Vector2(direction,1);
        rbEnemy.velocity = new Vector2(direction * enemySpeed*2, 0);

    }

    void LesuireMode()
    {
        if (IsAtEdge())
        {
            direction *= -1;
        }
        transform.localScale = new Vector2(direction,1);
        rbEnemy.velocity = new Vector2(direction * enemySpeed, 0);

    }
    
    bool IsAtEdge()
    {
	    // Cast our current BoxCollider in the current gravity direction.
        var hitLeft = Physics2D.BoxCast(
            bcEnemy.bounds.center, bcEnemy.bounds.size, 
            0.0f, new Vector2(-1,0), edgeCheckDistance, 
            edgeLayerMask);
        var hitRight = Physics2D.BoxCast(
            bcEnemy.bounds.center, bcEnemy.bounds.size, 
            0.0f, new Vector2(1,0), edgeCheckDistance, 
            edgeLayerMask);

        Debug.Log("vector: "+ Physics2D.gravity.normalized);
        return (hitLeft.collider != null || hitRight.collider != null);
    }
    
    
    
    
}
