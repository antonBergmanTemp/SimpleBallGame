using UnityEngine;

public class PlatformsGenerator : ObjectPool
{
    [SerializeField] private Platform _platformTemplate;

    private Vector3 _nextSpawnPosition;
    private Vector3 _lastSpawnPosition;

    private void Awake()
    {
        Inistialize(_platformTemplate.gameObject);
    }

    private void OnEnable()
    {
        StartGenerate();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _lastSpawnPosition) > _platformTemplate.transform.localScale.z)
        {
            DisableObjectsAboardScreen();
            if (TryGetObject(out GameObject platform))
            {
                SetPlatform(platform);
                _lastSpawnPosition = transform.position;
            }
        }
    }

    private void SetPlatform(GameObject platform)
    {
        platform.SetActive(true);
        platform.transform.position = _nextSpawnPosition;
        _nextSpawnPosition.z += platform.transform.localScale.z;
    }

    private void StartGenerate()
    {
        _nextSpawnPosition = transform.position;

        for (int i = 0; i < Pool.Count; i++)
        {
            if (TryGetObject(out GameObject platform))
            {
                SetPlatform(platform);
            }
        }
    }    
}
