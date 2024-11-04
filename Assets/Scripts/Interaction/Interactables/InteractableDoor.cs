using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private DoorAnimator _doorAnimator; 

    private bool _isOpen;
    
    public override string Prompt =>
        (_isOpen)
        ? $"Close {name}"
        : $"Open {name}";

    public override void OnRaycast(RaycastHit? maybeHit)
    {
        CanInteract = true;
    }
    
    public override void OnInteract()
    {
        if (_isOpen)
            _doorAnimator.Close();
        else
            _doorAnimator.Open();
    }

    public void __OnFullyOpened()
    {
        _isOpen = true;
        _doorAnimator.SetBoolIsOpen(_isOpen);
    }

    public void __OnFullyClosed()
    {
        _isOpen = false;
        _doorAnimator.SetBoolIsOpen(_isOpen);
    }
}
