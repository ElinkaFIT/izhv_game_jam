using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
//public Transform player;
    private Transform player;
    public float agroRange;
    public float enemySpeed = 4;
    private Animator anim;
    private float edgeCheckDistance = 0.00001f;
    private Rigidbody2D rbEnemy;
    private CapsuleCollider2D bcEnemy;
    public LayerMask edgeLayerMask;
    private float direction = 1.0f;
    public GameObject avatar1, avatar2;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rbEnemy = GetComponent<Rigidbody2D>();
        bcEnemy = GetComponent<CapsuleCollider2D>();
        player = GameObject.Find("Player").transform;
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        rbEnemy.gravityScale = 10.0f;
        
        // chasing player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        bool chasingAllowed = (distToPlayer < agroRange && player.position.y < transform.position.y + 2 &&
                               player.position.y > transform.position.y - 1);
       if (chasingAllowed )
        { ChasePlayerMode(); }
        else
        { LesuireMode(); }

    }

    void ChasePlayerMode()
    {
        if (transform.position.x < player.position.x)
            { direction = 1.0f; }   // player is to the right
        else if (transform.position.x > player.position.x)
            { direction = -1.0f; }  // player is to the left
        transform.localScale = new Vector2(direction,1);
        rbEnemy.velocity = new Vector2(direction * enemySpeed*2, 0);
        avatar1.gameObject.SetActive(false);
        avatar2.gameObject.SetActive(true);
        anim.SetBool("IsRunning", true);

    }

    void LesuireMode()
    {
        if ( IsAtEdge() )
        { direction *= -1; } //change direction at the edge
        transform.localScale = new Vector2(direction,1);
        rbEnemy.velocity = new Vector2(direction * enemySpeed, 0);
        avatar2.gameObject.SetActive(false);
        avatar1.gameObject.SetActive(true);
        anim.SetBool("IsSlow", true);

    }
    
    bool IsAtEdge()
    {
        var hitLeft = Physics2D.BoxCast(
            bcEnemy.bounds.center, bcEnemy.bounds.size, 
            0.0f, new Vector2(-1,0), edgeCheckDistance, 
            edgeLayerMask); //touches edge from left
        var hitRight = Physics2D.BoxCast(
            bcEnemy.bounds.center, bcEnemy.bounds.size, 
            0.0f, new Vector2(1,0), edgeCheckDistance, 
            edgeLayerMask); //touches edge from right

        Debug.Log("vector: "+ Physics2D.gravity.normalized);
        return (hitLeft.collider != null || hitRight.collider != null);
    }
    
    
    
    
}
