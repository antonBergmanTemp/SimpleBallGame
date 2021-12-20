using UnityEngine;
using TMPro;

public class UIPopup : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void ShowMassage(string text)
    {
        _text.SetText(text);
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
