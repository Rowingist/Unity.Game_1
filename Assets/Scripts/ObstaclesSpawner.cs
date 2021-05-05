using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : ObjectPool
{
    [SerializeField] private GameObject _obstacleTemplate;
    [SerializeField] private float _timeBetweenSpawn;

    private float _elapsedTime = 0;
    private float _disableViewPortPointX = -0.1f;

    private void Start()
    {
        Initialize(_obstacleTemplate);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime > _timeBetweenSpawn)
        {
            if(TryGetObject(out GameObject obstacle))
            {
                _elapsedTime = 0;

                Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                obstacle.SetActive(true);
                obstacle.transform.position = spawnPoint;

                DisableObjectsOutlineTheScreen(_disableViewPortPointX, gameObject.transform);
            }
        }
    }
}
