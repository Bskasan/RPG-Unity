using UnityEngine;


public class ThirdPersonMover : MonoBehaviour
{
    [Header("Movement & Rotation")]
    [SerializeField] private float _turnSpeed = 1000f;
    [SerializeField] private float _moveSpeed = 5f;
    
    private Rigidbody _rigidbody;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    private void Update()
    {
        var mouseMovement = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseMovement * Time.deltaTime * _turnSpeed, 0); // Rotate on Y axis.
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        var velocity = new Vector3(horizontal, 0, vertical);
        velocity *= _moveSpeed * Time.deltaTime;
        Vector3 offset = transform.rotation * velocity; // Direction we're facing / Directional Vector * Speed.
        _rigidbody.MovePosition(transform.position + offset);

    }
}
