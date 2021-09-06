using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private Camera _camera;
    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject[] prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prefab.Length);
            GameObject spawned = Instantiate(prefab[randomIndex], _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectAbroadCamera()
    {
        foreach (var item in _pool)
        {
            if (item.activeSelf == true)
            {
                Vector3 point = _camera.WorldToViewportPoint(item.transform.position);
                if (point.x < 0)
                {
                    item.SetActive(false);
                }
            }
        }
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
