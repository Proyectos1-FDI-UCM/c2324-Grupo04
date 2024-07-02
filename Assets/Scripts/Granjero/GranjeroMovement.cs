using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GranjeroMovement : MonoBehaviour
{
    #region references
    private PlayerAnimationController _AnimationController;
    private Rigidbody2D _rigidbody;
    private Player_Raycast _myRC;
    private bool _isClimbing = false;
    private float _climbSpeed = 5f; // Velocidad al subir o bajar escaleras
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
        _AnimationController = GetComponent<PlayerAnimationController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _myRC = GetComponent<Player_Raycast>();
        OvejaSoltada();
    }

    private void OnUp() // Método activado cada vez que el jugador introduce el input de saltar
    {
        if (_rigidbody.velocity.y < 0.1 && _myRC.ChoqueAbajo())
        {
            _currentFallSpeed = _jumpFallSpeed;
            _rigidbody.AddForce(Vector2.up * _currentJump, ForceMode2D.Impulse);
            //Llamada a la animación de salto
            _AnimationController.Salta();
        }
    }

    // Método que detecta cuándo el jugador ha soltado el botón de saltar
    // Nos permite hacer el salto más fácil de controlar
    private void OnStopJumping()
    {
        _currentFallSpeed = _fallSpeed;
        print("Jump stopped");
    }

    private void OnHorizontalMovement(InputValue value)
    {
        _movementDirection = value.Get<Vector2>(); // Este vector siempre tendrá la forma (1, 0) o (-1, 0)
        if (_movementDirection != Vector2.zero)
        {
            _movementTracker = _movementDirection;
            _AnimationController.Gira(_movementDirection.x);
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

    private void Update()
    {
        if (_isClimbing)
        {
            // Implementación del movimiento vertical (subir/bajar escaleras)
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _movementDirection.y * _climbSpeed);
        }
        else
        {
            // Implementación del movimiento horizontal normal
            if (_movementDirection.x < 0 && !_myRC.ChoqueIzq() || _movementDirection.x > 0 && !_myRC.ChoqueDer())
            {
                _rigidbody.velocity = _movementDirection * _currentSpeed + Vector2.up * _rigidbody.velocity.y;
                _currentSpeed += _acceleration * Time.deltaTime;
            }
            else
            {
                _currentSpeed = _baseSpeed;
            }

            // Aplicamos la gravedad
            _rigidbody.velocity += _currentFallSpeed * Vector2.down * Time.deltaTime;

            // Limitamos las velocidades
            _rigidbody.velocity = new Vector2(
                Mathf.Clamp(_rigidbody.velocity.x, -_maxSpeed, _maxSpeed),
                Mathf.Clamp(_rigidbody.velocity.y, -_maxFallSpeed, _maxVerticalSpeed)
            );
        }
    }

    public void OnUpStair()
    {
        _isClimbing = true;
        _movementDirection = Vector2.up; // Dirección de subida
        // Puedes agregar aquí cualquier lógica adicional según sea necesario
        Debug.Log("Subiendo escaleras");
    }

    public void OnDownStair()
    {
        _isClimbing = true;
        _movementDirection = Vector2.down; // Dirección de bajada
        // Puedes agregar aquí cualquier lógica adicional según sea necesario
        Debug.Log("Bajando escaleras");
    }

    public void OnStopStair()
    {
        _isClimbing = false;
        _movementDirection = Vector2.zero; // Detenemos el movimiento vertical
        // Puedes agregar aquí cualquier lógica adicional según sea necesario
        Debug.Log("Deteniendo escaleras");
    }
}

