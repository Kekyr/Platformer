using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _runForce;
    [SerializeField] private float _jumpForce;
    [SerializeField] private KeyCode _moveLeftButton;
    [SerializeField] private KeyCode _moveRightButton;
    [SerializeField] private KeyCode _jumpButton;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private Vector3 _moveDirection;
    private float _currentForce;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(_moveLeftButton))
        {
            Run(-transform.right, true);
        }

        if (Input.GetKey(_moveRightButton))
        {
            Run(transform.right, false);
        }

        if (Input.GetKey(_jumpButton))
        {
            Jump();
        }

        if (Input.anyKey == false)
        {
            Idle();
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.AddForce(_moveDirection * _currentForce);
    }

    private void Run(Vector3 moveDirection, bool isFlip)
    {
        _moveDirection = moveDirection;
        _spriteRenderer.flipX = isFlip;
        _currentForce = _runForce;
        _animator.SetBool("Run", true);
    }

    private void Jump()
    {
        _moveDirection = transform.up;
        _currentForce = _jumpForce;
    }

    private void Idle()
    {
        _moveDirection = Vector3.zero;
        _animator.SetBool("Run", false);
    }
}
