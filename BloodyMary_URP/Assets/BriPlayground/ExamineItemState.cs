using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Hertzole.GoldPlayer;
using PixelCrushers.DialogueSystem;
using PixelCrushers; 
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

    //don't think I will need this - clear them out of here
    private CinemachineVirtualCamera mainCamera; 
    private CinemachineVirtualCamera examinationCamera;

    public Material selectedMaterial;
    public Material baseMaterial; 
    
    // Start is called before the first frame update
    void Start()
    {
        examinationCamera = ServiceLocator._ExamineCamera;
        ChangeCondition();
      //  mainCamera = ServiceLocator._PlayerCamera; 


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
            if (baseMaterial != null)
            {
                gameObject.GetComponent<MeshRenderer>().material = baseMaterial; 
            }
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
            if (selectedMaterial != null)
            {
                gameObject.GetComponent<MeshRenderer>().material = selectedMaterial; 
            }
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
            
    
            currentState = ItemState.Idle;
            //code to put down
        }
    }

    public void ChangeView(string view)
    {
        Debug.Log("Came here instead oops");
        
        if (currentState == ItemState.ChangeView)
        {
           Debug.Log(view);
           ServiceLocator._SelectInterations.ItemChangeView(view);
           /*
            switch (view)
            {
                case "Key_ComputerMonitor": //this is messy find a way to do this neater
                    Debug.Log("Change to computer scene");
                    
                    
                    
                    ServiceLocator._Player.SetActive(false);
                    ServiceLocator._ComputerCamera.Priority = 11; 
                    
                    
                    ServiceLocator._2DComputerImage.SetActive(true);
                    ServiceLocator._Game.ChangeCursor("on"); // turning cursor on
                    ServiceLocator._ComputerManager.CurrentMessage();
                    currentState = ItemState.InView;
                    break;
                
            }*/ 
                
        } 
    }
    
    public void InView(string view)
    {
      Debug.Log("called inview");
      if (currentState == ItemState.InView)
      {
         
      }
        
        /*  if (currentState == ItemState.InView)
        {
            switch (view)
            {
                case "ComputerInteraction":
                   
                    //you'd be waiting for them to press the interaction key and close the computer?
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                      
                        
                    }

                    break;
                
            }
            

        }  */ 
        
      
    }

    public void ChangeCondition()
    {
        Debug.Log("we made it to here");
        //DialogueSystemTrigger.OnUse();
        DialogueManager.StartConversation("Day1_Erica"); 

    }
}
