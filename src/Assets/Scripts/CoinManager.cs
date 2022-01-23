using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text coinText;
    public static int coinAmount;
    
    void Start()
    {
        coinText = GetComponent<Text>();
    }

    void Update()
    {
         if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            coinText.text = coinAmount.ToString();
        }
    }
}
