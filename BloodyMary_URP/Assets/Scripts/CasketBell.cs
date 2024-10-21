using System;
using UnityEngine;

public class CasketBellInteractable : MonoBehaviour, IInteractable
{
    private ItemState currentState;
    private AudioSource audioSource;
    
    
    //base material is default - outline shows when you are in hover
    [SerializeField] private Material baseMaterial;
    [SerializeField] private Material outlineMaterial;

    private Renderer objectRenderer; 
    
    //will check how many times you ring the bell
    private int bellRings;
    private int bellRingsNeeded = 3;
    
    //conversation needed for bell rings
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
        if (bellRings >= bellRingsNeeded) //when you ring the bell over X amount we will call the wakeup sequence
        {
           
        }
       
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
            audioSource.Play(); // Play the audio clip
            bellRings++;
            BellAction();
            Debug.Log("Interacting with CasketBell");
            
            //currentState = ItemState.Examine; // Change state to examine or another state as needed (CasketBell does not have this need)
            // Additional interaction logic can go here
        }
    }

    public void ResetState()
    {
        Debug.Log("Called reset state on casket");
        
        currentState = ItemState.Idle; // Reset to idle
        // Optionally, revert visual changes made during hover
        if (objectRenderer != null && baseMaterial != null)
        {
            objectRenderer.material = baseMaterial;
        }
    }

    private void BellAction()
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
    }
}