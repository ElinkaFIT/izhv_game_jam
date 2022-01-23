using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    private GameObject player;
    
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.tag == "Player")
        {
            Destroy(this.gameObject); 
            CoinManager.coinAmount += 1;
        }
    }
    
    
}
