using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour, IInteractable
{
   private ItemState currentState;
    private AudioSource audioSource;
    
    
    //base material is default - outline shows when you are in hover
    [SerializeField] private Material baseMaterial;
    [SerializeField] private Material outlineMaterial;

    private Renderer objectRenderer; 
    
    
    //conversation needed for start of magazine, if i can use this script for the full section we can have her say multiple things during this
    [SerializeField] private GameObject conversationBell1;
    [SerializeField] private GameObject conversationBell2; 
    
    //Camera script that will transition us to the next scene
    private CameraPriority switchCamera; 

    void Start()
    {
        currentState = ItemState.Idle; // Initialize state
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
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
            Debug.Log("set the item state to Hover");
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
           // audioSource.Play(); // Play the audio clip
            Debug.Log("Interacting with Magazine");
            
            currentState = ItemState.Examine; //  do we make a general version or will you always changed scenes on interactions? 
            
            switchCamera.SetCameraHighestPriority();
            // Additional interaction logic can go here
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

    /* private void BellAction()   may be able to use something like this on
    {
        switch (bellRings)
        {
           case 1:
               conversationBell1.SetActive(true);
               
               currentState = ItemState.Idle; // Reset to idle
               // Optionally, revert visual changes made during hover
               if (objectRenderer != null && baseMaterial != null)
               {
                   objectRenderer.material = baseMaterial;
               }
               break;
           case 2 :
               conversationBell2.SetActive(true);
               currentState = ItemState.Idle; // Reset to idle
               // Optionally, revert visual changes made during hover
               if (objectRenderer != null && baseMaterial != null)
               {
                   objectRenderer.material = baseMaterial;
               }
               break;
           case 3 :
               switchCamera.SetCameraHighestPriority();
               Debug.Log("Set camera priority");
               break;
        }
    } */ 
    
}

