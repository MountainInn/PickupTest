using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool CanInteract { get; protected set; }
    
    public abstract string Prompt { get; }
    
    public abstract void OnRaycast(RaycastHit? maybeHit);
    public abstract void OnInteract();
}
