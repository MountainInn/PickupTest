using UnityEngine;

public class PlayerCharacterMouseLook : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private float _rotationYLimit = 85;

    public Quaternion LookRotation {get; private set;}
    
    private float _rotationX;
    private float _rotationY;

    private Transform _cameraTransform;

    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _rotationX += Input.GetAxis("Mouse X") * _mouseSensitivity;

        _rotationY += Input.GetAxis("Mouse Y") * _mouseSensitivity;
        _rotationY = Mathf.Clamp(_rotationY, -_rotationYLimit, _rotationYLimit);

        var quaternionX = Quaternion.AngleAxis(_rotationX, Vector3.up);
        var quaternionY = Quaternion.AngleAxis(_rotationY, Vector3.left);

        LookRotation = quaternionX * quaternionY;

        _cameraTransform.localRotation = LookRotation;
    }
}
