using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float enemySpeed;
    public MoveForward playerRef; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the enemy a set speed left or right
        transform.Translate(Vector3.right  * Time.deltaTime * enemySpeed);
        
        //check zones what zone the player is in
        //if the player is in the second zone the speed of the cars should be quicker
        if (playerRef.zoneNumber > 1)
        {
            enemySpeed += enemySpeed + 3; 
        }
    }
}
