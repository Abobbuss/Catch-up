using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BotMovement : MonoBehaviour
{
    public Transform _player;
    public float _speed = 4.0f;
    public float _stopDistance = 2.0f;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.position);

        if (distanceToPlayer > _stopDistance)
        {
            Vector3 direction = (_player.position - transform.position).normalized;
            Vector3 move = direction * _speed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(transform.position + move);
        }
    }
}
