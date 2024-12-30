using Cinemachine;
using UnityEngine;

public class MagazineInteractable2D : MonoBehaviour, IInteractable2D
{
    private ItemState currentState;

    private SpriteRenderer spriteRenderer;
    [SerializeField] private Color hoverColor = Color.yellow;
    private Color originalColor;
    [SerializeField] private BoxCollider2D hideObjectColliderAfter1, hideObjectColliderAfter2;
    [SerializeField] private GameObject nextAnswer1, nextAnswer2; 

    void Start()
    {
        currentState = ItemState.Idle;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer != null ? spriteRenderer.color : Color.white;

        // Debug: Initialization success
        // Debug.Log("MagazineInteractable2D initialized. Original color: " + originalColor);
    }

    public void OnHover2D()
    {
        // Debug: Hover called
        // Debug.Log("OnHover2D called. Current state: " + currentState);

        if (currentState == ItemState.Idle)
        {
            // Debug: Changing to hover state
            // Debug.Log("Changing state to Hover and changing color.");
            spriteRenderer.color = hoverColor;
            currentState = ItemState.Hover;
        }
        else
        {
            // Debug: Hover called but already in another state
            // Debug.Log("OnHover2D called, but current state is not Idle. State: " + currentState);
        }
    }

    public void OnInteract2D()
    {
        // Debug: Interact called
        // Debug.Log("OnInteract2D called. Current state: " + currentState);

        if (currentState == ItemState.Hover)
        {
            // Debug: Interacting from Hover
             Debug.Log("Interacting with Magazine: changing camera.");
            
            gameObject.GetComponent<CameraPriority>().ChangeCameraBlendEase();
            gameObject.GetComponent<CameraPriority>().SetCameraBlend();
            
            //Turn on the next items
            hideObjectColliderAfter1.enabled =false;
            if (hideObjectColliderAfter2 != null)
            {
                hideObjectColliderAfter2.enabled = false;
            }

            if (nextAnswer1 != null)
            {
                nextAnswer1.SetActive(true);
            }

            if (nextAnswer2 != null)
            {
                nextAnswer2.SetActive(true);
            }

            // Optionally update state if needed
            currentState = ItemState.Examine;
        }
        else
        {
            // Debug: Interact called but item is not in hover state
            // Debug.Log("OnInteract2D called but current state is: " + currentState + ". No interaction performed.");
        }
    }

    public void ResetState2D()
    {
        // Debug: Reset state called
        // Debug.Log("ResetState2D called. Returning to Idle state.");

        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
        }
        currentState = ItemState.Idle;
    }
    
    public void TurnOffCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
