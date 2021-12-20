using UnityEngine;
using TMPro;

public class RecordsViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _recordsText;
    [SerializeField] private ScoreViewer _scoreViewer;

    private int[] _records = new int[3];
    private GameData _gameData;
    private Storage _storage;

    private void Awake()
    {
        _storage = new Storage();
        _gameData = new GameData();
        Load();
    }

    private void OnEnable()
    {
        Load();
        InsertResultToRecords();
        ShowRecords();
    }

    private void InsertResultToRecords()
    {
        for (int i = 0; i < _records.Length; i++)
        {
            if (_scoreViewer.Scores > _records[i])
            {
                for (int j = _records.Length - 1; j > i; j--)
                {
                    _records[j] = _records[j - 1];
                }
                _records[i] = _scoreViewer.Scores;
                break;
            }
        }
        Save();
    }

    private void ShowRecords()
    {
        _recordsText.text = "";
        for (int i = 0; i < _records.Length; i++)
        {
            _recordsText.text += $"{i + 1}. {_records[i]}\n";
        }
    }

    private void Save()
    {
        _gameData.Records = _records;
        _storage.Save(_gameData);
    }

    private void Load()
    {
        _gameData = (GameData)_storage.Load(new GameData());
        _records = _gameData.Records;
    }

}
