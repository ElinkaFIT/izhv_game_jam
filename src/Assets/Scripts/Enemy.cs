using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform player;
    
    [SerializeField] float agroRange;
    
    [SerializeField] float speed;

    private Rigidbody2D rbEnemy;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Enemy position: " + transform.position);
        Debug.Log("Player position: " + player.position);
        
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange)
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
            rbEnemy.velocity = new Vector2(speed, 0);
        }
        else if (transform.position.x > player.position.x)
        {   // player is to the left
            rbEnemy.velocity = new Vector2(-speed, 0);
        }
        
    }

    void LesuireMode()
    {
        
        
    }
    
    
}
