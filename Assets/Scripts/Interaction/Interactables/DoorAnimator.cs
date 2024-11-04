using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    [SerializeField] private string _triggerInteractName = "Interact";
    [SerializeField] private string _boolIsOpenName = "IsOpen";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        _animator.SetTrigger(_triggerInteractName);
    }

    
    public void Close()
    {
        _animator.SetTrigger(_triggerInteractName);
    }


    public void SetBoolIsOpen(bool isOpen)
    {
        _animator.SetBool(_boolIsOpenName, isOpen);
    }
}
