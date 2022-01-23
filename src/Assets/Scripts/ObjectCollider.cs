using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{  
     public Transform player;
     BoxCollider2D bcObject;
    
    void Start()
    {
        bcObject = GetComponent<BoxCollider2D>();
        
    }

    void Update()
    {
        if (player.position.y > (transform.position.y + 1.5))
        {
            bcObject.isTrigger = false;
        }
        else
        {
             bcObject.isTrigger = true;
         }
    }
}
