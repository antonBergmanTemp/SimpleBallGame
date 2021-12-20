using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private BallMover _ball;
    [SerializeField] private float _beforeBallDistance;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, _ball.transform.position.z - _beforeBallDistance);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, (_speed + _ball.CarrentSpeed) * Time.fixedDeltaTime);
    }
}
