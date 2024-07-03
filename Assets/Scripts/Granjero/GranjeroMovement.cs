using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GranjeroMovement : MonoBehaviour
{
    #region references
    private PlayerAnimationController _myAnimationController;
    private Rigidbody2D _myRB;
    private Player_Raycast _myRC;
    private Collider2D _ladderCollider;
    #endregion

    #region parameters
    [SerializeField] private float _sheepJumpForce = 18;
    [SerializeField] private float _jumpForce = 24;
    [SerializeField] private float _maxSpeed = 6;
    [SerializeField] private float _baseSpeed = 2.5f;
    [SerializeField] private float _acceleration = 6;
    [SerializeField] private float _jumpFallSpeed = 4;
    [SerializeField] private float _fallSpeed = 4;
    [SerializeField] private float _maxFallSpeed = 4;
    [SerializeField] private float _maxVerticalSpeed = 40;
    [SerializeField] private float _climbSpeed = 4;
    [SerializeField] private float _climbLimit = 6.3f;
    #endregion

    #region variables
    private Vector2 _movementDirection;
    public Vector2 _movementTracker;
    private float _currentJump = 0;
    private float _currentFallSpeed;
    private float _currentSpeed = 0f;
    private float _climbStartY = 0f;
    private bool _onLadder = false;
    private bool _isClimbing = false;
    #endregion

    public Vector2 Movement() // Método que permite saber la dirección en la que está mirando el jugador
    {
        return _movementTracker;
    }

    private void Start()
    {
        _maxFallSpeed = _jumpForce;
        _currentFallSpeed = _fallSpeed;
        _myAnimationController = GetComponent<PlayerAnimationController>();
        _myRB = GetComponent<Rigidbody2D>();
        _myRC = GetComponent<Player_Raycast>();
        OvejaSoltada();
    }

    private void OnUp()
    {
        if (_onLadder && !_isClimbing)
        {
            StartClimbing();
        }
        else if (_myRB.velocity.y < 0.1 && _myRC.ChoqueAbajo())
        {
            _currentFallSpeed = _jumpFallSpeed;
            _myRB.AddForce(Vector2.up * _currentJump, ForceMode2D.Impulse);
            _myAnimationController.Salta();
        }
    }

    private void StartClimbing()
    {
        _isClimbing = true;
        _climbStartY = _myRB.position.y;
        _myRB.gravityScale = 0; // Desactivar la gravedad mientras se sube la escalera
        _myRB.velocity = new Vector2(_myRB.velocity.x, _climbSpeed);
    }

    private void StopClimbing()
    {
        _isClimbing = false;
        _myRB.gravityScale = 1; // Restaurar la gravedad
        _myRB.velocity = new Vector2(_myRB.velocity.x, 0);
    }

    private void OnStopJumping()
    {
        _currentFallSpeed = _fallSpeed;
        if (_isClimbing)
        {
            StopClimbing();
        }
        print("Jump stopped");
    }

    private void OnHorizontalMovement(InputValue value)
    {
        _movementDirection = value.Get<Vector2>();
        if (_movementDirection != Vector2.zero)
        {
            _movementTracker = _movementDirection;
            _myAnimationController.Gira(_movementDirection.x);
        }
    }

    public void OvejaSoltada()
    {
        _currentJump = _jumpForce;
    }

    public void OvejaRecogida()
    {
        _currentJump = _sheepJumpForce;
    }

    private void FixedUpdate()
    {
        if (_isClimbing)
        {
            if (Mathf.Abs(_myRB.position.y - _climbStartY) >= _climbLimit)
            {
                StopClimbing();
            }
        }
        else
        {
            if (_movementDirection.x < 0 && !_myRC.ChoqueIzq() || _movementDirection.x > 0 && !_myRC.ChoqueDer())
            {
                _myRB.velocity = _movementDirection * _currentSpeed + Vector2.up * _myRB.velocity.y;
                _currentSpeed += _acceleration * Time.deltaTime;
                print($"Velocidad horizontal: {_myRB.velocity.x}");
            }
            else
            {
                _currentSpeed = _baseSpeed;
            }

            // Aplicamos la gravedad (tiene que ser manualmente para un mejor control del salto)
            _myRB.velocity += _currentFallSpeed * Vector2.down * Time.deltaTime;

            _myRB.velocity = Mathf.Clamp(_myRB.velocity.x, -_maxSpeed, _maxSpeed) * Vector2.right
                           + Mathf.Clamp(_myRB.velocity.y, -_maxFallSpeed, _maxVerticalSpeed) * Vector2.up;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ladder"))
        {
            _onLadder = true;
            _ladderCollider = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == _ladderCollider)
        {
            _onLadder = false;
            _ladderCollider = null;
        }
    }
}
