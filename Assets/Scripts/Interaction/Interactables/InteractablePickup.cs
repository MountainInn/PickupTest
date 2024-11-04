using UnityEngine;
using Zenject;

public class InteractablePickup : Interactable
{
    [Inject] private Hand _hand;

    public override string Prompt => $"Pickup {name}";

    public BoxCollider Collider { get; private set; }

    void Awake()
    {
        Collider = GetComponent<BoxCollider>();
    }

    public override void OnRaycast(RaycastHit? maybeHit)
    {
        CanInteract = !_hand.IsHoldingObject;
    }

    public override void OnInteract()
    {
        _hand.Pickup(this);
    }
}
