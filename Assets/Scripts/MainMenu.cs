using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private GameMenu _gameMenu;
    [SerializeField] private BallMover _ball;
    [SerializeField] private WaveGenerator _spawner;

    private Vector3 _ballStartPosition;
    private Vector3 _cameraStartPosition;

    private void Start()
    {
        _ballStartPosition = _ball.transform.position;
        _cameraStartPosition = Camera.main.transform.position;
        _spawner.gameObject.SetActive(false);
        _ball.gameObject.SetActive(false);
    }

    public void OnStartGame()
    {
        Time.timeScale = 1;
        _mainMenu.gameObject.SetActive(false);
        _gameMenu.gameObject.SetActive(true);
        SetStartSettings();
        _spawner.gameObject.SetActive(true);
        _ball.gameObject.SetActive(true);
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }

    private void SetStartSettings()
    {
        _ball.transform.position = _ballStartPosition;
        Camera.main.transform.position = _cameraStartPosition;
    }
}
