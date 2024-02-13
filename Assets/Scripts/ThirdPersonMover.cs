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

    private void Awake()
    { 
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

    }

    private void Update() => _mouseMovement += Input.GetAxis("Mouse X");

    private void FixedUpdate()
    {
        if(ToggleablePanel.IsVisible == false)
            transform.Rotate(0, _mouseMovement * Time.deltaTime * _turnSpeed, 0); // Rotate on Y axis.

        _mouseMovement = 0f;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
            vertical *= 2f;
        
        var velocity = new Vector3(horizontal, 0, vertical);
        velocity *= _moveSpeed * Time.fixedDeltaTime;
        Vector3 offset = transform.rotation * velocity; // Direction we're facing / Directional Vector * Speed.
        _rigidbody.MovePosition(transform.position + offset);

        _animator.SetFloat("Vertical", vertical, 0.1f, Time.deltaTime);
        _animator.SetFloat("Horizontal", horizontal, 0.1f, Time.deltaTime);

    }
}
