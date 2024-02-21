using UnityEngine;
using UnityEngine.UIElements;


public class ThirdPersonMover : MonoBehaviour
{
    [Header("Movement & Rotation")]
    [SerializeField] private float _turnSpeed = 1000f;
    [SerializeField] private float _moveSpeed = 5f;
    
    private Rigidbody _rigidbody;
    private Animator _animator;
    private float _mouseMovement;
    private float _horizontal;
    private float _vertical;

    private void Awake()
    { 
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update() => _mouseMovement += Input.GetAxis("Mouse X");

    private void FixedUpdate()
    {
        if (ToggleablePanel.IsVisible == false)
            PlayerRotation();

        _mouseMovement = 0f;

        ReadInput();

        if (RunButtonPressed())
            _vertical *= 2f;

        MovePlayer();

        UpdateAnimation();

    }

    private void PlayerRotation()
    {
        transform.Rotate(0, _mouseMovement * Time.deltaTime * _turnSpeed, 0); // Rotate on Y axis.
    }

    private void MovePlayer()
    {
        var velocity = new Vector3(_horizontal, 0, _vertical);
        velocity *= _moveSpeed * Time.fixedDeltaTime;
        Vector3 offset = transform.rotation * velocity; // Direction we're facing / Directional Vector * Speed.
        _rigidbody.MovePosition(transform.position + offset);
    }

    private void UpdateAnimation()
    {
        _animator.SetFloat("Vertical", _vertical, 0.1f, Time.deltaTime);
        _animator.SetFloat("Horizontal", _horizontal, 0.1f, Time.deltaTime);
    }

    private void ReadInput()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    private static bool RunButtonPressed()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }
}
