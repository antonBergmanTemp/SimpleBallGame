using System.Collections;
using UnityEngine;

public class GameAnimations : MonoBehaviour
{
    [SerializeField] private UIPopup _popup;
    [SerializeField] private BallMover _ballMover;

    [SerializeField] private float _countMassageTime;

    private void OnEnable()
    {
        _ballMover.enabled = false;
        StartCoroutine(ShowStartAnimation());
    }

    private IEnumerator ShowStartAnimation()
    {
        //yield return new WaitForSeconds(_countMassageTime);
        _popup.ShowMassage("3");
        yield return new WaitForSeconds(_countMassageTime);
        _popup.ShowMassage("2");
        yield return new WaitForSeconds(_countMassageTime);
        _popup.ShowMassage("1");
        yield return new WaitForSeconds(_countMassageTime);
        _popup.ShowMassage("Gooooo");
        _ballMover.enabled = true;
    }

}
