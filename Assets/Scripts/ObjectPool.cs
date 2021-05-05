using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private Camera _camera;
    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for(int i = 0; i < _capacity; i++)
        {
            GameObject spawnedObject = Instantiate(prefab, _container.transform);
            spawnedObject.SetActive(false);

            _pool.Add(spawnedObject);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectsOutlineTheScreen(float disablePointX, Transform disablePointY)
    {
        foreach (var item in _pool)
        {
            Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector3(disablePointX, disablePointY.position.y));

            if (item.activeSelf == true)
            {
                if (item.transform.position.x > disablePoint.x)
                    item.SetActive(false);
            }
        }
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
            item.SetActive(false);
    }
}
