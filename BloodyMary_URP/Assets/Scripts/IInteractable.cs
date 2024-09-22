public interface IInteractable //using interface so that it decouples script, and allows for flexibility with additional items
{
    void OnInteract(); // this way we can have different interaction on different items
    void OnHover();
    void ResetState();
}
