using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private GameOverPannelCotroller _gameOverpannelController;
    [SerializeField] private Animator _animator;

    private Player _player;

    public event UnityAction PlayerHasDied;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        { 
            _player.EncreaseScore();
            coin.DestroyCoin();
        }

        if (collision.TryGetComponent(out Obstacle obstacle))
        {
            PlayerHasDied?.Invoke();
            _gameOverpannelController.OpenPanel();
            _animator.enabled = false;
        }
    }
}
