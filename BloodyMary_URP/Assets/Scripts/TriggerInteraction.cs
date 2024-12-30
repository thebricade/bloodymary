using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TriggerInteraction : MonoBehaviour, IInteractable
{
    private ItemState currentState;
    private AudioSource audioSource;
    
    
    //base material is default - outline shows when you are in hover
    [SerializeField] private Material baseMaterial;
    [SerializeField] private Material outlineMaterial;

    private Renderer objectRenderer; 
    
    
    //conversation needed for start of magazine, if i can use this script for the full section we can have her say multiple things during this
    [SerializeField] private GameObject conversation1;
    

    void Start()
    {
        currentState = ItemState.Idle; // Initialize state
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component

        objectRenderer = GetComponent<Renderer>();
        
        //Make sure there is a base material at the start
        if (objectRenderer != null && baseMaterial != null)
        {
            objectRenderer.material = baseMaterial;
        }
    }

    public void Update()
    {
        
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
            objectRenderer.material = baseMaterial;
            // Additional interaction logic can go here
            if (conversation1 != null)
            {
                conversation1.SetActive(true);
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

}

