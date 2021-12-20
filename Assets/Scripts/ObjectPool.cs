using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform Container;
    [SerializeField] private int _capacity;

    protected List<GameObject> Pool = new List<GameObject>();

    private Camera _camera;

    protected void Inistialize(GameObject[] prefabs)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            int prefabNumber = Random.Range(0, prefabs.Length);

            GameObject spawnedGameObject = Instantiate(prefabs[prefabNumber], Container);
            spawnedGameObject.SetActive(false);
            Pool.Add(spawnedGameObject);
        }
    }

    protected void Inistialize(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawnedGameObject = Instantiate(prefab, Container);
            spawnedGameObject.SetActive(false);
            Pool.Add(spawnedGameObject);
        }        
    }

    protected bool TryGetRandomObject(out GameObject result)
    {
        var notActiveObjects = Pool.Where(o => o.activeSelf.Equals(false)).ToList();

        if (notActiveObjects.Count == 0)
        {
            result = null;
            return false;
        }

        int randomObjectNumber = Random.Range(0, notActiveObjects.Count);

        result = notActiveObjects[randomObjectNumber];

        return true;
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = Pool.FirstOrDefault(p => p.activeSelf == false);
        
        return result != null;
    }

    protected void DisableObjectsAboardScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0.5f, 0));

        foreach (var item in Pool)
        {
            if (item.activeSelf == true)
            {
                if (item.transform.position.z + item.transform.localScale.z / 2 < disablePoint.z)
                {
                    item.SetActive(false);
                }
            }
        }
    }  

    public void ResetPool()
    {
        foreach (var item in Pool)
        {
            item.SetActive(false);
        }
    }
}
