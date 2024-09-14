using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private float _speed;
    private Transform _target;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _speed = 10f;        
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _direction * _speed;
    }

    public void Init(Vector3 direction, Transform target)
    {
        _direction = direction;
        _target = target;
    }
}
