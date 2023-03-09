using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemState
{
    Idle,
    Hover,
    Examine,
    PutDown
}

public class ExamineItem : MonoBehaviour
{
    public ItemState currentState;

    public void Idle()
    {
        if (currentState == null)
        {
            
            currentState = ItemState.Idle; 
            //code to idle
        }
        else
        {
            Debug.Log("reset to idle");
            currentState = ItemState.Idle;
        }
    }

    public void Hover()
    {
        if (currentState == ItemState.Idle)
        {
            Debug.Log("moving to hover");
            currentState = ItemState.Hover;
            //code to pickup item
        }
    }

    public void Examine()
    {
        if (currentState == ItemState.Hover)
        {
            Debug.Log("moving to examine");
            currentState = ItemState.Examine; 
            //code to examine
        }
    }

    public void PutDown()
    {
        if (currentState == ItemState.Examine)
        {
            Debug.Log("moving to putdown");
            currentState =ItemState.PutDown; 
            //code to put down
        }
    }
    


// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
