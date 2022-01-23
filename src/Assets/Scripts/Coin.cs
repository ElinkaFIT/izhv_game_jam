using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
     private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        */
         if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
            /*
             if (MemberManager.lives  == 2)
                CoinManager.coinAmount += 2;
            else
            */
                CoinManager.coinAmount += 1;
        }
    }
    
    
}
