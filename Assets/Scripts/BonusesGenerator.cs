using UnityEngine;
using System.Linq;

public class BonusesGenerator : ObjectPool
{
    [SerializeField] private GameObject _coinTemplate;
    [SerializeField] private GameObject _bonusTemplate;
    [SerializeField] private float _coinOffsetX;
    [SerializeField] private Transform _bonusContainer;

    private Vector3 _nextSpawnPosition;
    private float _distanceZ;
    private GameObject _bonus;

    private void Awake()
    {
        Inistialize(_coinTemplate);
        _bonus = Instantiate(_bonusTemplate, _bonusContainer);
        _bonus.SetActive(false);
    }

    public void CreateCoinsWave(float spawnDelay, float obstaclesDistanceZ, int coinsBetweenObstaclesCount, int obstaclesCount)
    {
        _distanceZ = obstaclesDistanceZ / (coinsBetweenObstaclesCount + 1);
        _nextSpawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + spawnDelay + _distanceZ);
        RandomizeSpawnPositionX();

        for (int i = 0; i < obstaclesCount - 1; i++)
        {
            for (int j = 0; j < coinsBetweenObstaclesCount; j++)
            {
                if (TryGetObject(out GameObject coin))
                    SetCoin(coin);
            }
            _nextSpawnPosition.z += _distanceZ;
            RandomizeSpawnPositionX();
        }
        ReplaceCoinToBonus();
    }

    private void SetCoin(GameObject coin)
    {
        coin.SetActive(true);
        coin.transform.position = new Vector3(_nextSpawnPosition.x, coin.transform.position.y, _nextSpawnPosition.z);
        _nextSpawnPosition.z += _distanceZ;
    }

    private void RandomizeSpawnPositionX()
    {
        int spawnPointNumber = Random.Range(0, 3);        

        if (spawnPointNumber == 0)
            _nextSpawnPosition.x = -_coinOffsetX;
        else if (spawnPointNumber == 1)
            _nextSpawnPosition.x = 0;
        else
            _nextSpawnPosition.x = _coinOffsetX;
    }

    private void ReplaceCoinToBonus()
    {
        var activeCoins = Pool.Where(c => c.activeSelf.Equals(true)).ToList();
        int randomCoinNumber = Random.Range(0, activeCoins.Count);

        _bonus.SetActive(true);
        _bonus.transform.position = activeCoins[randomCoinNumber].transform.position;
        activeCoins[randomCoinNumber].SetActive(false);
    }
}
