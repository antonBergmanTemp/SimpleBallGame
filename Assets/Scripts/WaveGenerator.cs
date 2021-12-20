using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _obstaclesDistanceZ;
    [SerializeField] private int _obstaclesCount;
    [SerializeField] private float _gameAcceleration;
    [SerializeField] private int _coinsBetweenObstaclesCount;
    [SerializeField] private Transform _container;
    [SerializeField] private ObstaclesGenerator _obstaclesGenerator;
    [SerializeField] private BonusesGenerator _coinsGenerator;

    [SerializeField] private UIPopup _popup;

    private GameObject _endWaveTrigger;

    private void Awake()
    {
        _endWaveTrigger = CreateEndWaveTrigger();
    }

    private void OnEnable()
    {
        _endWaveTrigger.GetComponent<EndWave>().WaveEnded += OnWaveEnded;
        CreateWave();
    }

    private void OnDisable()
    {
        if (_endWaveTrigger != null)
            _endWaveTrigger.GetComponent<EndWave>().WaveEnded -= OnWaveEnded;
    }

    private void CreateWave()
    {
        Vector3 endWavePoint = _obstaclesGenerator.CreateObstaclesWave(_spawnDelay, _obstaclesDistanceZ, _obstaclesCount);
        _coinsGenerator.CreateCoinsWave(_spawnDelay, _obstaclesDistanceZ, _coinsBetweenObstaclesCount, _obstaclesCount);
        SetEndWavePosition(endWavePoint);
    }

    private GameObject CreateEndWaveTrigger()
    {
        GameObject endWaveTrigger = new GameObject();
        endWaveTrigger.name = "EndWave";
        endWaveTrigger.transform.parent = _container;
        endWaveTrigger.AddComponent<BoxCollider>().isTrigger = true;
        endWaveTrigger.AddComponent<EndWave>();
        return endWaveTrigger;
    }

    private void SetEndWavePosition(Vector3 position)
    {
        _endWaveTrigger.SetActive(true);
        _endWaveTrigger.transform.position = position;
    }

    private void OnWaveEnded(EndWave endWave)
    {
        ShowEndWaveMassage();
        DisableObjectsInContainer();
        CreateWave();
        Time.timeScale += _gameAcceleration;
    }

    private void DisableObjectsInContainer()
    {
        foreach (Transform item in _container)
            item.gameObject.SetActive(false);
    }

    private void ShowEndWaveMassage()
    {
        string[] massages = new string[] {"Coool", "Just do it", "Keep it up"};

        int massageNumber = Random.Range(0, massages.Length);

        _popup.ShowMassage(massages[massageNumber]);

    }
}
