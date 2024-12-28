using UnityEngine;

public class InteractionController2D : MonoBehaviour
{
    private IInteractable2D currentInteractable;

    void Update()
    {
        // Debug: Check if we're skipping interaction due to dialogue
        // Debug.Log("InteractionController2D Update called.");

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Debug: Show the converted mouse position
        // Debug.Log("Mouse world position: " + mousePos);

        Collider2D hitCollider = Physics2D.OverlapPoint(mousePos);

        if (hitCollider != null)
        {
            // Debug: Indicate we hit a collider
             Debug.Log("Hit collider: " + hitCollider.gameObject.name);

            IInteractable2D interactable = hitCollider.GetComponent<IInteractable2D>();

            if (interactable != null)
            {
                // Debug: We found a valid interactable
                 Debug.Log("Interactable found: " + interactable.ToString());

                if (currentInteractable != interactable)
                {
                    // Debug: Changing current interactable
                    // Debug.Log("New interactable detected. Previous was: " + (currentInteractable != null ? currentInteractable.ToString() : "None"));

                    if (currentInteractable != null)
                    {
                        // Debug: Resetting previous interactable
                        // Debug.Log("Resetting previous interactable: " + currentInteractable.ToString());
                        currentInteractable.ResetState2D();
                    }

                    currentInteractable = interactable;
                }

                // Debug: OnHover2D being called
                // Debug.Log("Calling OnHover2D on: " + currentInteractable.ToString());
                currentInteractable.OnHover2D();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Debug: Interaction key pressed
                    // Debug.Log("E key pressed. Calling OnInteract2D.");
                    currentInteractable.OnInteract2D();
                }
            }
            else
            {
                // Debug: Hit a collider without IInteractable2D
                // Debug.Log("Collider " + hitCollider.gameObject.name + " doesn't implement IInteractable2D.");

                if (currentInteractable != null)
                {
                    // Debug: Reset current interactable since we hit a non-interactable
                    // Debug.Log("Resetting current interactable: " + currentInteractable.ToString());
                    currentInteractable.ResetState2D();
                    currentInteractable = null;
                }
            }
        }
        else
        {
            // Debug: No collider hit
            // Debug.Log("No collider hit at mouse position.");

            if (currentInteractable != null)
            {
                // Debug: Reset current interactable since we hit nothing this frame
                // Debug.Log("Resetting current interactable: " + currentInteractable.ToString());
                currentInteractable.ResetState2D();
                currentInteractable = null;
            }
        }
    }
}
