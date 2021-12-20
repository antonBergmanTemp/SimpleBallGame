using UnityEngine;
using TMPro;

public class ChargesViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private CollisionHandler _handler;

    private void OnEnable()
    {
        _text.SetText("");
        _handler.BonusChargesChanged += OnBonusChargesChanged;
    }

    private void OnDisable()
    {
        _handler.BonusChargesChanged -= OnBonusChargesChanged;
    }

    private void OnBonusChargesChanged(int chargesValue)
    {
        if (chargesValue == 0)
        {
            _text.SetText("");
        }
        else
        {
            _text.SetText(chargesValue.ToString());
        }
    }
}
