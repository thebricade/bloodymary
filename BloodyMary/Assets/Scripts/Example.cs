using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    public int playerLives; // a whole number
    public bool isGameOver; // 2 values only true or false
   
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player ran the start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player ran the update");

        if (playerLives < 1)  // is going to check if something is true or false
        {
           // warn the player
           isGameOver = true; 
        }

       
    }
}
