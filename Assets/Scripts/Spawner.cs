using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnByTime))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectsPool _objecstPool;
    [SerializeField] private GameObject _spawnObjectTemplate;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _quantityObjectsPerSpawn;
    [SerializeField] private int _distanceBetwenObjects;
    [SerializeField] private float _disableViewPortPointX;

    private void Awake()
    {
        _objecstPool.Initialize(_spawnObjectTemplate);
    }

    public void SpawnObject()
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
