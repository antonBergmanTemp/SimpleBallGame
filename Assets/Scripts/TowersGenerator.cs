using UnityEngine;

public class TowersGenerator : ObjectPool
{
    [SerializeField] private GameObject[] _towerTemplates;
    [SerializeField] private float _distanceBetweenTowersZ;
    [SerializeField] private float _halfDistanceBetweenTowersX;

    private Vector3 _nextSpawnPosition;
    private Vector3 _lastSpawnPosition;

    private void Awake()
    {
        Inistialize(_towerTemplates);
    }

    private void OnEnable()
    {
        StartGenerate();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _lastSpawnPosition) > _distanceBetweenTowersZ)
        {
            DisableObjectsAboardScreen();
            SetTowersLine();
            _lastSpawnPosition = transform.position;
        }
    }

    private void SetTowersLine()
    {
        if (TryGetRandomObject(out GameObject rightTower))
            SetTower(rightTower, _halfDistanceBetweenTowersX);

        if (TryGetRandomObject(out GameObject leftTower))
            SetTower(leftTower, -_halfDistanceBetweenTowersX);

        _nextSpawnPosition.z += _distanceBetweenTowersZ;
    }

    private void SetTower(GameObject tower, float positionOffsetX)
    {
        tower.SetActive(true);
        tower.transform.position = _nextSpawnPosition + new Vector3(positionOffsetX, 0, 0);
    }

    public void StartGenerate()
    {
        _nextSpawnPosition = transform.position;

        for (int i = 0; i < Pool.Count / 2; i++)
        {
            SetTowersLine();
        }
        _lastSpawnPosition = transform.position;
    }    
}
