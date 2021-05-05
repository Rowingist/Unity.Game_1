using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider), typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] private float _gravityScale;

    private Rigidbody _rigidbody;
    private SphereCollider _sphereCollider;
    private PlayerCollisionHandler _playerCollisionHandler;

    private const float _globalGravity = -9.8f;
    private int _score;

    public event UnityAction<int> ScoreHasChanged;

    private void Awake()
    {
        _playerCollisionHandler = GetComponent<PlayerCollisionHandler>();
    }

    private void OnEnable()
    {
        _playerCollisionHandler.PlayerHasDied += OnDied;
    }

    private void OnDisable()
    {
        _playerCollisionHandler.PlayerHasDied -= OnDied;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector3(-_movingSpeed, _rigidbody.velocity.y);

        if (!CheckIfFlying() && Input.GetKeyDown(KeyCode.Space))
            _rigidbody.velocity = Vector3.up * _jumpVelocity;
    }

    private void FixedUpdate()
    {
        Vector3 gravity = _globalGravity * _gravityScale * Vector3.up;
        _rigidbody.AddForce(gravity, ForceMode.Acceleration);
    }

    private bool CheckIfFlying()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);

        return Physics.SphereCast(groundRay, _sphereCollider.radius);
    }

    public void EncreaseScore()
    {
        _score++;
        ScoreHasChanged?.Invoke(_score);
    }

    public void OnDied()
    {
        _movingSpeed = 0;
        _jumpVelocity = 0;
    }
}
