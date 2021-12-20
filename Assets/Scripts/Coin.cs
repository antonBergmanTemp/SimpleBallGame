using UnityEngine;

public class Coin : InteractiveObject
{
    [SerializeField] private int _scoreValue;

    public int ScoreValue => _scoreValue;
}
