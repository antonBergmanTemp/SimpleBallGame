using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CollisionHandler))]

public class BallMover : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _deflectionSpeed;
    [SerializeField] private float _bonusSpeed;
    [SerializeField] [Range(0.5f, 1)] private float _inputFieldShare;

    public float CarrentSpeed => _currentSpeed;

    private CollisionHandler _handler;
    private Rigidbody _rigidbody;
    private float _currentSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _handler = GetComponent<CollisionHandler>();
        _currentSpeed = _speed;
    }

    private void OnEnable()
    {
        _handler.BonusChargesChanged += OnBonusChargesChanged;
    }

    private void OnDisable()
    {
        _handler.BonusChargesChanged -= OnBonusChargesChanged;
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector3(0, 0, _currentSpeed);

        if (Input.GetMouseButton(0))
        {
            float screenWidthHalf = Camera.main.scaledPixelWidth * 0.5f;

            float targetPositionXNomalized = Mathf.Clamp(Input.mousePosition.x - screenWidthHalf, -screenWidthHalf * _inputFieldShare, screenWidthHalf * _inputFieldShare) / (Camera.main.scaledPixelWidth * _inputFieldShare);

            float deltaPositionX = targetPositionXNomalized - transform.position.x;

            _rigidbody.velocity = new Vector3(deltaPositionX * _deflectionSpeed, 0, _rigidbody.velocity.z);
        }
    }

    private void OnBonusChargesChanged(int bonusCharges)
    {
        if (bonusCharges == 0)
            _currentSpeed = _speed;
        else
            _currentSpeed = _bonusSpeed;
    }
}
