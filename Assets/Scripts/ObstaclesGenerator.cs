using UnityEngine;

public class ObstaclesGenerator : ObjectPool
{
    [SerializeField] private GameObject[] _obstacleTemplates;
    
    private Vector3 _nextSpawnPosition;
    private float _distanceZ;

    private void Awake()
    {
        Inistialize(_obstacleTemplates);
    }

    public Vector3 CreateObstaclesWave(float spawnDelay, float _obstaclesDistanceZ, int count)
    {
        _nextSpawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + spawnDelay);
        _distanceZ = _obstaclesDistanceZ;

        for (int i = 0; i < count; i++)
        {
            if (TryGetRandomObject(out GameObject obstacle))
            {
                SetObstacle(obstacle);                
            }
        }
        return _nextSpawnPosition;
    }

    private void SetObstacle(GameObject obstacle)
    {
        obstacle.SetActive(true);
        obstacle.transform.position = new Vector3(obstacle.transform.position.x, obstacle.transform.position.y, _nextSpawnPosition.z);
        _nextSpawnPosition.z += _distanceZ;
    }
}
