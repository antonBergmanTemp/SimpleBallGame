using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private CollisionHandler _handler;

    public int Scores => _scores;

    private int _scores;

    private void OnEnable()
    {
        _scores = 0;
        _text.SetText("Scores: " + _scores);
        _handler.CoinCatched += OnCoinCatched;
    }

    private void OnDisable()
    {
        _handler.CoinCatched -= OnCoinCatched;
    }

    private void OnCoinCatched(int scoresValue)
    {
        _scores += scoresValue;
        _text.SetText("Scores: " + _scores);
    }
}
