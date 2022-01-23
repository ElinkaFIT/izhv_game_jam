using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text coinText;
    public static int coinAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
         if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            coinText.text = coinAmount.ToString();
        }
    }
}
