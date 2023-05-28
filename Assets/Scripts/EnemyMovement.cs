using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Transform _endPosition;

    private SpriteRenderer _spriteRenderer;
    private Vector3 _targetPosition;
    private Vector3 _startPosition;
    private float _runningTime;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startPosition = transform.position;
        _targetPosition = _endPosition.position;
    }

    private void FixedUpdate()
    {
        if (transform.position == _targetPosition)
        {
            ChangeMoveDirection();
        }

        _runningTime += Time.deltaTime;

        float speed = _runningTime / _duration;

        transform.position = Vector3.Lerp(_startPosition, _targetPosition, speed);
    }

    private void ChangeMoveDirection()
    {
        Vector3 temporaryPosition = _startPosition;
        _startPosition = _targetPosition;
        _targetPosition = temporaryPosition;
        _runningTime = 0;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}
