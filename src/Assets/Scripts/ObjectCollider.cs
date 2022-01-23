using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{  
     public Transform player;
     BoxCollider2D bcObject;
    
    // Start is called before the first frame update
    void Start()
    {
        bcObject = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {Debug.Log("player: " + player.position.y + " ..object: "+ (transform.position.y + 1.5));
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
