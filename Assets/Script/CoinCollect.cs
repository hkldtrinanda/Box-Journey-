using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CoinCollect : MonoBehaviour
{
    /*public TextMeshProUGUI scoreText;*/
    
    public GameObject coin;
    
    public GameManager gameManager;

    
    // Start is called before the first frame update
    void Start()
    {
        
        /*scoreText.text = " : " + ScoreNum;*/
        coin.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D (Collider2D Collision)
    {
        if (Collision.tag == "Coin")
        {   
            gameManager.counter++;
            coin.SetActive(true);
            /*scoreText.text = " : " + ScoreNum;*/
            
            Destroy(Collision.gameObject);
        }
    }
}