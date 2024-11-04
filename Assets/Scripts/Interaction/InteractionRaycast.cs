using UnityEngine;
using UniRx;

public class InteractionRaycast : MonoBehaviour
{
    [SerializeField] [Min(1)] private float _interactionDistance;
    [Space]
    [SerializeField] private LayerMask _interactableLayerMask;

    private Transform _cameraTransform;
    private RaycastHit[] _hits;

    readonly public ReactiveProperty<Interactable> Interactable = new();
    
    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
        _hits = new RaycastHit[1];
    }

    private void Update()
    {
        int hitCount = Physics.RaycastNonAlloc(_cameraTransform.position,
                                               _cameraTransform.forward,
                                               _hits,
                                               _interactionDistance,
                                               _interactableLayerMask,
                                               QueryTriggerInteraction.UseGlobal);

        if (hitCount > 0)
        {
            GameObject go = _hits[0].collider.gameObject;
            
            if (go.TryGetComponent(out Interactable interactable))
            {
                this.Interactable.Value = interactable;
                this.Interactable.Value.OnRaycast(_hits[0]);
            }
        }
        else
        {
            this.Interactable.Value?.OnRaycast(null);

            this.Interactable.Value = null;
        }

        if (Interactable.Value != null &&
            Interactable.Value.CanInteract &&
            Input.GetMouseButtonDown(0))
        {
            Interactable.Value.OnInteract();
        }
    }
}
