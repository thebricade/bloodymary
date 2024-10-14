using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private IInteractable currentInteractable;

    void Update()
    {
        if (PixelCrushers.DialogueSystem.DialogueManager.IsConversationActive) return; // If dialogue is happening, don't do anything
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            
            if (interactable != null) //if we hit something with an IInteractable component
            {
                if (currentInteractable != interactable)
                {
                    // If we're hovering over a new object, reset the old one
                    if (currentInteractable != null)
                    {
                        currentInteractable.ResetState();
                    }

                    currentInteractable = interactable; //this is the current interactable we're focused on
                }

                // Call OnHover when mouse is over the object
                interactable.OnHover();

                // Check for interaction key press
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.OnInteract();
                }
            }
            else //I hit on object that doesn't have an IInteractable component
            {
                if (currentInteractable != null)
                {
                    currentInteractable.ResetState();
                    currentInteractable = null;
                }
            }
        }
        else
        {
            // If nothing is hit by the raycast, reset the current interactable
            if (currentInteractable != null)
            {
                currentInteractable.ResetState();
                currentInteractable = null;
            }
        }
    }
}