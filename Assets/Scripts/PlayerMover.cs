using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] private float _gravityScale;

    private Rigidbody _rigidbody;
    private SphereCollider _sphereCollider;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
            _rigidbody.velocity = Vector3.up * _jumpVelocity;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(-_movingSpeed, _rigidbody.velocity.y);


        Vector3 gravity = Physics.gravity * _gravityScale;
        _rigidbody.AddForce(gravity, ForceMode.Acceleration);
    }

    private bool IsGrounded()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);

        return !Physics.SphereCast(groundRay, _sphereCollider.radius);
    }

    public void StopMoving()
    {
        _movingSpeed = 0;
        _jumpVelocity = 0;
    }
}
