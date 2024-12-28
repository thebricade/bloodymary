using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInteractions : MonoBehaviour, IInteractable
{
    private ItemState currentState;
    private AudioSource _audioSource;
    

    //base material is default - outline shows when you are in hover
    [SerializeField] private Material baseMaterial;
    [SerializeField] private Material outlineMaterial;

    private Renderer objectRenderer;
    [SerializeField] private GameObject nextSceneParent;

    void Start()
    {
        currentState = ItemState.Idle; // Initialize state
        _audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        //switchCamera = GetComponent<CameraPriority>();


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
            Debug.Log("Interacting with an item with sound");
            TurnOnOffMusic();
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

    private void TurnOnOffMusic()
    {
       Debug.Log("Changed Sound");
        if(_audioSource.isPlaying)
            _audioSource.Stop();
        else _audioSource.Play();
    }
    private void TurnOnObjects()
    {
        nextSceneParent.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}