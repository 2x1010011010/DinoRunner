using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactiGenerator : ObjectPool
{
    [SerializeField] private GameObject[] _template;
    [SerializeField] private Vector3 _spawnPoint;
    [SerializeField] private int _minSecondsBetweenSpawn;
    [SerializeField] private int _maxSecondsBetweenSpawn;

    private float _elapsedTime;
    private int _randomTimeBetweenSpawn;

    private void Start()
    {
        Initialize(_template);
        _randomTimeBetweenSpawn = _maxSecondsBetweenSpawn;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _randomTimeBetweenSpawn)
        {
            if (TryGetObject(out GameObject cactus))
            {
                _elapsedTime = 0;

                cactus.transform.position = new Vector3(transform.position.x, _spawnPoint.y, transform.position.z);
                cactus.SetActive(true);

                _randomTimeBetweenSpawn = Random.Range(_minSecondsBetweenSpawn, _maxSecondsBetweenSpawn);
                DisableObjectAbroadCamera();
            }
        }
    }
}
