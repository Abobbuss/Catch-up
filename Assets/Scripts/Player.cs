using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 6.0f;
    [SerializeField] private float _gravity = -9.81f;

    private CharacterController _controller;
    private Vector3 _velocity;
    private string _horizontalInput = "Horizontal";
    private string _verticalInput = "Vertical";

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_controller.isGrounded && _velocity.y < 0)
            _velocity.y = -2f;

        float moveX = Input.GetAxis(_horizontalInput);
        float moveZ = Input.GetAxis(_verticalInput);
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        _controller.Move(move * _speed * Time.deltaTime);

        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
