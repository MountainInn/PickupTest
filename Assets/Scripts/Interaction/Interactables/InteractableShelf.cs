using UnityEngine;
using DG.Tweening;
using Zenject;

public class InteractablePutdown : Interactable
{
    [Inject] private Hand _hand;

    private Vector3 _putPosition;   

    public override string Prompt => $"Put into {name}";
    
    public override void OnRaycast(RaycastHit? maybeHit)
    {
        if (maybeHit.HasValue && _hand.IsHoldingObject)
        {
            RaycastHit hit = maybeHit.Value;

            /// 
            /// Положить предмет можно только на поверхность, нормаль которой смотрит вверх
            /// 
            float dot = Vector3.Dot(Vector3.up, hit.normal);
            CanInteract = (dot > 0);

            _putPosition = hit.collider.transform.InverseTransformPoint(hit.point);
        }
        else
        {
            CanInteract = false;
        }
    }
    
    public override void OnInteract()
    {
        _hand.Putdown(transform, _putPosition);
    }
}
