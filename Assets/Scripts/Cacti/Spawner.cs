using UnityEngine;

namespace Cacti
{
  public class Spawner : ObjectPool
  {
    [SerializeField] private GameObject[] _template;
    [SerializeField] private Vector3 _spawnPoint;
    [SerializeField] private float _minSecondsBetweenSpawn;
    [SerializeField] private float _maxSecondsBetweenSpawn;

    private float _elapsedTime;
    private float _randomTimeBetweenSpawn;
    private float _speed = 5f;
    
    public void SetSpeed(float speed) => 
      _speed = speed;

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

          cactus.transform.position = _spawnPoint;
          cactus.SetActive(true);
          cactus.GetComponent<CactusMover>().SetSpeed(_speed);

          _randomTimeBetweenSpawn = Random.Range(_minSecondsBetweenSpawn, _maxSecondsBetweenSpawn);
          DisableObjectAbroadCamera();
        }
      }
    }
  }
}