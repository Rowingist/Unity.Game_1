using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Spawner))]
public class SpawnByTime : MonoBehaviour
{
    [SerializeField] private float _timeBetweenSpawn;

    private Spawner _spawner;
    private float _spawnDeltaTime;

    private void Start()
    {
        _spawner = GetComponent<Spawner>();
    }

    private void Update()
    {
        _spawnDeltaTime += Time.deltaTime;

        if (_spawnDeltaTime > _timeBetweenSpawn)
        {
            _spawnDeltaTime = 0f;
            _spawner.SpawnObject();
        }
    }   
}
