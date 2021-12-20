using UnityEngine;

public class MenuChanger : MonoBehaviour
{
    [SerializeField] private GameObject _currentMenu;
    [SerializeField] private GameObject _targetMenu;
    public void OnChange()
    {
        _currentMenu.SetActive(false);
        _targetMenu.SetActive(true);
    }
}
