using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChangeCameraInteraction : MonoBehaviour, IInteractable
{
    private ItemState currentState;
    private AudioSource audioSource;
    
    
    //base material is default - outline shows when you are in hover
    [SerializeField] private Material baseMaterial;
    [SerializeField] private Material outlineMaterial;
    private Renderer objectRenderer; 
    
    //conversation needed for start of magazine, if i can use this script for the full section we can have her say multiple things during this
    [SerializeField] private GameObject conversation1, conversationLocked;
    
    //Camera script that will transition us to the next scene
    private CameraPriority switchCamera;
    [SerializeField] private GameObject nextSceneParent;
    
    //check if there's a condition that needs to be met before continuing. 
    [SerializeField] private bool metCondition; 
    
    void Start()
    {
        Debug.Log($"start from camerainteraction called on {gameObject.name}", this);
        
        currentState = ItemState.Idle; // Initialize state
        //audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        
        switchCamera = GetComponent<CameraPriority>();  
        objectRenderer = GetComponent<Renderer>();
        //Make sure there is a base material at the start
        if (objectRenderer != null && baseMaterial != null)
        {
            objectRenderer.material = baseMaterial;
        }
    }

    public void Update()
    {
        Debug.Log(currentState);
    }

    public void OnHover()
    {
       
        if (currentState == ItemState.Idle)
        {
            Debug.Log($"start from camerainteraction called on {gameObject.name}", this);
            
            currentState = ItemState.Hover; // Change state to hover
            
            // Optionally, change the material or highlight the object
            if (objectRenderer != null && outlineMaterial != null)
            {
                objectRenderer.material = outlineMaterial;
            }
        }
       
    }

    public void OnInteract()
    {
        if (currentState == ItemState.Hover)
        {
           // audioSource.Play(); // Play the audio clip probably sound effect when interacting with object
           if (metCondition)
           {
               TurnOnObjects(); //makes it so that you can see the cursor
               if (switchCamera != null)
               {
                   switchCamera.SetCameraHighestPriority(); //changes camera
               }

               gameObject.GetComponent<BoxCollider>().enabled = false;
               objectRenderer.material = baseMaterial;

               // if you want to fire a conversation when you change the scene, alt is you can have it tied to the object that is being set active
               if (conversation1 != null)
               {
                   conversation1.SetActive(true);
               }
           }else 
           {
               // play VO that hints at progress
               conversationLocked.SetActive(true);
           }
        }
    }

    public void OnExamine() // do we need this? 
    {
        
    }

    public void ResetState()
    {
        Debug.Log("Called reset state on Magazine");
        
        currentState = ItemState.Idle; // Reset to idle
        // Optionally, revert visual changes made during hover
        if (objectRenderer != null && baseMaterial != null)
        {
            objectRenderer.material = baseMaterial;
        }
    }

    private void TurnOnObjects()
    {
          nextSceneParent.SetActive(true);
          Cursor.lockState = CursorLockMode.None;
          Cursor.visible = true;
    }

    public void setCondition()
    {
        metCondition = true; 
    }
}

