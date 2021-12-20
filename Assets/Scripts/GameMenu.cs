using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private CollisionHandler _handler;
    [SerializeField] private WaveGenerator _spawner;
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _notInteractiveObjectsContainer;
    [SerializeField] private GameObject _interactiveObjectsContainer;

    private void OnEnable()
    {
        _handler.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _handler.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        _handler.gameObject.SetActive(false);
        _spawner.gameObject.SetActive(false);
        DisableObjectsInContainer(_notInteractiveObjectsContainer);
        DisableObjectsInContainer(_interactiveObjectsContainer);
        _gameOverMenu.SetActive(true);
        _gameMenu.SetActive(false);
    }

    private void DisableObjectsInContainer(GameObject conteiner)
    {
        foreach (Transform item in conteiner.transform)
            item.gameObject.SetActive(false);
    }
}
