using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerCharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    [Inject] private PlayerCharacterMouseLook _mouseLook;
    [Inject] private CharacterController _characterController;

    private Vector3 _inputDirection;
    private Vector3 _characterDirection;
    private Vector3 _movementDirection;
    private Vector3 _motion;
    
    private Transform _cameraTransform;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        _characterDirection = _cameraTransform.forward;
        _characterDirection.y = 0;
        _characterDirection.Normalize();
        
        _inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        _movementDirection = Quaternion.LookRotation(_characterDirection) * _inputDirection;

        _motion = _movementDirection * _speed;
    }

    private void FixedUpdate()
    {
        _characterController.SimpleMove(_motion);
    }
}
