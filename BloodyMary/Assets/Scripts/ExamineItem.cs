using System.Collections;
using System.Collections.Generic;
using Cinemachine;
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
    public bool canExamine;

    public Camera mainCamera; 
    public Camera examinationCamera;

    
    // Start is called before the first frame update
    void Start()
    {
        //startPos = gameObject.transform.position; 
    }
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
        
        if (currentState == ItemState.Hover)
        {
            Debug.Log("we are in the hover");
            if (canExamine && Input.GetKeyDown(KeyCode.Q)) // would change if there's an item you can pickup
            {
                Debug.Log("moving to examine");
                currentState = ItemState.Examine; 

            }
        }
    }

    public void Examine()
    {
        if (currentState == ItemState.Examine)
        {
            Debug.Log("in examine");
            
            //currently moved this to happen at an early state. need to change it so it does not move the position 
            //because that will show us the camera moving to that spot we want a clean cut to the new camera. 
            
            // Set the position and rotation of the examination camera to match the transform
           examinationCamera.transform.position = transform.position + Vector3.up * 2f; // 2f is offset
           examinationCamera.transform.LookAt(transform);

           // Set the examination camera as a child of the game object
            examinationCamera.transform.SetParent(transform,false);
            //add in visual effect show that you are hovering over an interactable item
            
            // Activate the examination camera
            examinationCamera.gameObject.SetActive(true);
            
            // Deactivate the main camera
            mainCamera.gameObject.SetActive(false);

           //check to see if we are pressing the interaction key again if we are lets exit the item
           if (Input.GetKeyDown(KeyCode.Q))
           {
               currentState = ItemState.PutDown; 
           }

            

        }
    }

    public void PutDown()
    {
        if (currentState == ItemState.PutDown)
        {
            Debug.Log("moving to putdown");
            
            //change camera back to main camera
            mainCamera.gameObject.SetActive(true);
            examinationCamera.gameObject.SetActive(false);

            //code to put down
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
