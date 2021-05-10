using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnTimer))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectsPool _objecstPool;
    [SerializeField] private GameObject _spawnObjectTemplate;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _quantityObjectsPerSpawn;
    [SerializeField] private int _distanceBetwenObjects;
    [SerializeField] private float _disableViewPortPointX;

    private SpawnTimer _spawnTimer;

    private void Awake()
    {
        _spawnTimer = GetComponent<SpawnTimer>();
        _objecstPool.Initialize(_spawnObjectTemplate);
    }

    private void OnEnable()
    {
        _spawnTimer.SpawnStarted += OnObjectSpawn;
    }

    private void OnDisable()
    {
        _spawnTimer.SpawnStarted -= OnObjectSpawn;
    }

    private void OnObjectSpawn()
    {
        int objectGap = 0;
        int _randomSpawnPoint = Random.Range(0, _spawnPoints.Length);

        for (int i = 0; i < _quantityObjectsPerSpawn; i++)
        {
            if (_objecstPool.TryGetObject(out GameObject spawnObject))
            {
                spawnObject.SetActive(true);
                spawnObject.transform.position = _spawnPoints[_randomSpawnPoint].transform.position + new Vector3(objectGap, 0, 0);
                objectGap += _distanceBetwenObjects;
                
                _objecstPool.DisableObjectsOutlineTheScreen(_disableViewPortPointX, gameObject.transform);
            }
        }
    }
}
