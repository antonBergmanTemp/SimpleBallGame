using System.Collections;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AudioSource _disableSound;
    [SerializeField] private float _disabledDelay;

    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Collider _collider;

    private Coroutine _corutine;

    private void OnDisable()
    {
        if (_corutine != null)
            StopCoroutine(_corutine);
        _meshRenderer.enabled = true;
        _collider.enabled = true;
    }
    public void Disable()
    {
        _disableSound.Play();
        _meshRenderer.enabled = false;
        _collider.enabled = false;
        _particleSystem.Play();
        _corutine = StartCoroutine(DisableBy(_disabledDelay));
    }

    private IEnumerator DisableBy(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
