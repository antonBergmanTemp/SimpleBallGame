using UnityEngine;
using TMPro;

public class YourScoresViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ScoreViewer _viewer;

    private void OnEnable()
    {
        _text.SetText("Your Scores\n" + _viewer.Scores);
    }
}
