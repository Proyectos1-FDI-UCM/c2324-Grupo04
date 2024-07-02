using System;
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
    private bool _isClimbing = false;
    private float _climbSpeed = 5f; // Velocidad al subir o bajar escaleras
    private Collider2D _currentLadderCollider; // Collider de la escalera actual
    private Vector2 _topOfLadderPosition; // Posición más alta de la escalera
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
    #endregion

    #region variables
    private Vector2 _movementDirection;
    private Vector2 _movementTracker;
    private float _currentJump = 0;
    private float _currentFallSpeed;
    private float _currentSpeed = 0f;
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

    private void OnUp() // Método activado cada vez que el jugador introduce el input de saltar
    {
        if (_myRB.velocity.y < 0.1 && _myRC.ChoqueAbajo())
        {
            _currentFallSpeed = _jumpFallSpeed;
            _myRB.AddForce(Vector2.up * _currentJump, ForceMode2D.Impulse);
            // Llamada a la animación de salto
            _myAnimationController.Salta();
        }
    }

    // Método que detecta cuándo el jugador ha soltado el botón de saltar
    private void OnStopJumping()
    {
        _currentFallSpeed = _fallSpeed;
        Debug.Log("Jump stopped");
    }

    private void OnHorizontalMovement(InputValue value)
    {
        _movementDirection = value.Get<Vector2>(); // Este vector siempre tendrá la forma (1, 0) o (-1, 0)

        if (_movementDirection != Vector2.zero)
        {
            _movementTracker = _movementDirection;
            _myAnimationController.Gira(_movementDirection.x);
        }
    }

    public void OnUpStair()
    {
        if (_currentLadderCollider != null && !_isClimbing)
        {
            _isClimbing = true;
            _movementDirection = Vector2.up; // Dirección de subida
            _topOfLadderPosition = _currentLadderCollider.bounds.max; // Posición más alta de la escalera
            Debug.Log("Subiendo escaleras");
        }
    }

    public void OnDownStair()
    {
        if (_currentLadderCollider != null && !_isClimbing)
        {
            _isClimbing = true;
            _movementDirection = Vector2.down; // Dirección de bajada
            Debug.Log("Bajando escaleras");
        }
    }

    public void OnStopStair()
    {
        _isClimbing = false;
        _movementDirection = Vector2.zero; // Detenemos el movimiento vertical
        Debug.Log("Deteniendo escaleras");
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
            // Movimiento vertical en la escalera
            _myRB.velocity = new Vector2(_myRB.velocity.x, _movementDirection.y * _climbSpeed);

            // Detener el movimiento al llegar al punto más alto de la escalera
            if (_movementDirection == Vector2.up && transform.position.y >= _topOfLadderPosition.y)
            {
                OnStopStair();
            }
            else if (_movementDirection == Vector2.down && transform.position.y <= _currentLadderCollider.bounds.min.y)
            {
                OnStopStair();
            }
        }
        else
        {
            // Movimiento horizontal normal
            if (_movementDirection.x < 0 && !_myRC.ChoqueIzq() || _movementDirection.x > 0 && !_myRC.ChoqueDer())
            {
                _myRB.velocity = _movementDirection * _currentSpeed + Vector2.up * _myRB.velocity.y;
                _currentSpeed += _acceleration * Time.deltaTime;
            }
            else
            {
                _currentSpeed = _baseSpeed;
            }

            // Aplicamos la gravedad manualmente para un mejor control del salto
            _myRB.velocity += _currentFallSpeed * Vector2.down * Time.deltaTime;

            // Limitación de las velocidades
            _myRB.velocity = new Vector2(
                Mathf.Clamp(_myRB.velocity.x, -_maxSpeed, _maxSpeed),
                Mathf.Clamp(_myRB.velocity.y, -_maxFallSpeed, _maxVerticalSpeed)
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            _currentLadderCollider = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == _currentLadderCollider)
        {
            _currentLadderCollider = null;
            OnStopStair();
        }
    }

    internal void SetStairPointsFromCollider(BoxCollider2D stairCollider)
    {
        throw new NotImplementedException();
    }
}

