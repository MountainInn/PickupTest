using UnityEngine;
using TMPro;
using UniRx;
using Zenject;

public class InteractionLabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;

    [Inject] private InteractionRaycast _interactionRaycast;

    private void Awake()
    {
        _interactionRaycast
            .Interactable
            .Subscribe(interactable =>
            {
                if (interactable == null) 
                {
                    _label.text = string.Empty;
                }
                else
                {
                    _label.text = interactable.Prompt;
                }
            })
            .AddTo(this);
    }
}
