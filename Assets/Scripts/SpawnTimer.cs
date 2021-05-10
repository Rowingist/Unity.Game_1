using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnTimer : MonoBehaviour
{
    [SerializeField] private float _timeBetweenSpawn;
    
    private float _spawnDeltaTime;

    public event UnityAction SpawnStarted;

    private void Update()
    {
        _spawnDeltaTime += Time.deltaTime;

        if (CompareCoinsSpawnTimes())
        {
            _spawnDeltaTime = 0f;
            SpawnStarted?.Invoke();
        }
    }

    private bool CompareCoinsSpawnTimes()
    {
        return _spawnDeltaTime > _timeBetweenSpawn;
    }
}
