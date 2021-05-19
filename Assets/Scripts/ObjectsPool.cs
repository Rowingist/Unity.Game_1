using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private int _capacity;

    private Camera _camera;
    private List<GameObject> _pool = new List<GameObject>();

    public void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for(int i = 0; i < _capacity; i++)
        {
            GameObject spawnedObject = Instantiate(prefab, transform);
            spawnedObject.SetActive(false);

            _pool.Add(spawnedObject);
        }
    }

    public bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    public void DisableObjectsOutlineTheScreen(float disablePointX, float disablePointY)
    {
        foreach (var item in _pool)
        {
            Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector3(disablePointX, disablePointY));

            if (item.activeSelf == true)
            {
                if (item.transform.position.x > disablePoint.x)
                    item.SetActive(false);
            }
        }
    }
}
