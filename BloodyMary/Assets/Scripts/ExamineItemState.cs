using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Hertzole.GoldPlayer;
using UnityEngine;


public enum ItemState
{
    Idle,
    Hover,
    Examine,
    PutDown,
    ChangeView,
    InView,
}

public class ExamineItemState : MonoBehaviour
{
    public ItemState currentState;
    public bool canExamine;
    public bool changeView; 

    private CinemachineVirtualCamera mainCamera; 
    private CinemachineVirtualCamera examinationCamera;

    
    // Start is called before the first frame update
    void Start()
    {
        examinationCamera = ServiceLocator._ExamineCamera;
        mainCamera = ServiceLocator._PlayerCamera; 


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
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (changeView)
                {
                    Debug.Log("moving to Change View");
                    currentState = ItemState.ChangeView; 
                }

                if (canExamine)
                {
                    Debug.Log("moving to examine");
                    currentState = ItemState.Examine;
                }
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
            ServiceLocator._Player.GetComponent<GoldPlayerController>().Camera.CanLookAround = false;
            ServiceLocator._Player.GetComponent<GoldPlayerController>().Movement.CanMoveAround = false;

           //check to see if we are pressing the interaction key again if we are lets exit the item
           if (Input.GetKeyDown(KeyCode.E))
           {
               Debug.Log("Pressed E during examine");
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
            examinationCamera.gameObject.SetActive(false);
            
            ServiceLocator._Player.SetActive(true);
            ServiceLocator._Game.ChangeCursor("off");
            ServiceLocator._Player.GetComponent<GoldPlayerController>().Camera.CanLookAround = true;
            ServiceLocator._Player.GetComponent<GoldPlayerController>().Movement.CanMoveAround = true;
            ServiceLocator._PlayerCamera.Priority = 11; 
            
         
            currentState = ItemState.Idle;
            //code to put down
        }
    }

    public void ChangeView(string view)
    {
        if (currentState == ItemState.ChangeView)
        {
           Debug.Log(view);
            switch (view)
            {
                case "ComputerInteraction": //this is messy find a way to do this neater
                    Debug.Log("Change to computer scene");
                    ServiceLocator._Player.SetActive(false);
                    ServiceLocator._ComputerCamera.Priority = 11; 
                    
                    
                    ServiceLocator._2DComputerImage.SetActive(true);
                    ServiceLocator._Game.ChangeCursor("on"); // turning cursor on
                    ServiceLocator._ComputerManager.CurrentMessage();
                    currentState = ItemState.InView;
                    break;
                
            }
                
        }
    }
    
    public void InView(string view)
    {
        if (currentState == ItemState.InView)
        {
            switch (view)
            {
                case "ComputerInteraction":
                   
                    //you'd be waiting for them to press the interaction key and close the computer?
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("Pressed E during InView");
                        ServiceLocator._ComputerCamera.Priority = 10; 
                        ServiceLocator._2DComputerImage.SetActive(false);
                        
                        currentState = ItemState.PutDown;
                        
                    }

                    break;
                
            }
            

        } 
        
      
    }
    

}
