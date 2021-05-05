using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : ObjectPool
{
    [SerializeField] private GameObject _coinTemplate;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _timeBentwenCoinSpawn;

    private int _maxCoinSpawnQuantity = 4;
    private int _distanceBetwenCoins;
    private float _elapsedTime = 0;
    private float _disableViewPortPointX = -0.2f;

    private void Start()
    {
        Initialize(_coinTemplate);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _timeBentwenCoinSpawn)
        {
            _elapsedTime = 0;
            _distanceBetwenCoins = 0;
            int _randomSpawnPoint = Random.Range(0, _spawnPoints.Length);

            for (int i = 0; i < _maxCoinSpawnQuantity; i++)
            {
                if (TryGetObject(out GameObject coin))
                {
                    coin.SetActive(true);
                    coin.transform.position = new Vector3(_spawnPoints[_randomSpawnPoint].transform.position.x - _distanceBetwenCoins, _spawnPoints[_randomSpawnPoint].transform.position.y, _spawnPoints[_randomSpawnPoint].transform.position.z);
                    _distanceBetwenCoins += 2;

                    DisableObjectsOutlineTheScreen(_disableViewPortPointX, gameObject.transform);
                }
            }
        }
    }
}
