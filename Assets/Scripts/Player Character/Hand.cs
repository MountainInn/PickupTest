using UnityEngine;
using DG.Tweening;

public class Hand : MonoBehaviour
{
    [SerializeField] private float _putdownDuration;
    [SerializeField] private float _pickupDuration;

    private InteractablePickup _heldObject;
    private Transform _heldTransform;
    private int _layerBeforePickup;

    public bool IsHoldingObject => _heldObject != null;

    public void Pickup(InteractablePickup pickableObject)
    {
        _heldObject = pickableObject;
        
        _layerBeforePickup = _heldObject.gameObject.layer;

        _heldObject.gameObject.layer = 0;
        
        _heldTransform = _heldObject.transform;
        _heldTransform.SetParent(transform, true);
        _heldTransform.DOLocalMove(Vector3.zero, _pickupDuration);
    }

    public void Putdown(Transform shelfTransform, Vector3 putPosition)
    {
        Vector3 putEuler = _heldTransform.eulerAngles;
        putEuler.x = 0;
        putEuler.z = 0;


        BoxCollider heldCollider = _heldObject.Collider;

        float offsetY = heldCollider.size.y / 2 - heldCollider.center.y;

        putPosition.y += offsetY;
        

        _heldTransform.SetParent(shelfTransform, true);
        _heldTransform.DOLocalMove(putPosition, _putdownDuration);
        _heldTransform.DORotate(putEuler, _putdownDuration);

        _heldObject.gameObject.layer = _layerBeforePickup;
        
        _heldObject = null;
        _heldTransform = null;
    }
}
