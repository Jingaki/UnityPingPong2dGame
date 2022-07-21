using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    float _speed = 20.0f;
    Rigidbody _rigidbody;
    Vector3 _velocoty;
    Renderer _renderer;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        Invoke("Lauch", 0.5f);
    }

    void Lauch()
    {
        _rigidbody.velocity = Vector3.up * _speed;
    }

    
    void FixedUpdate()
    {
        _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
        _velocoty = _rigidbody.velocity;

        if (!_renderer.isVisible)
        {
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rigidbody.velocity = Vector3.Reflect(_velocoty, collision.contacts[0].normal);
    }
}
