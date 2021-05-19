using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover), typeof(PlayerCollision))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private PlayerCollision _playerCollision;

    private int _coins;

    public event UnityAction<int> CoinCollected;

    private void Awake()
    {
        _playerCollision = GetComponent<PlayerCollision>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _playerCollision.PlayerDied += OnDied;
    }

    private void OnDisable()
    {
        _playerCollision.PlayerDied -= OnDied;
    }

    public void AddCoin()
    {
        _coins++;
        CoinCollected?.Invoke(_coins);
    }

    public void OnDied()
    {
        _playerMover.StopMoving();
    }
}
