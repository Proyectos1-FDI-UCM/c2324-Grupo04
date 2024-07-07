using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GranjeroMovement : MonoBehaviour
{
    #region references
    private PlayerAnimationController _myAnimationController;
    private Rigidbody2D _myRB; // Esto estaba p�blico por alguna raz�n? - R
    private Player_Raycast _myRC;
    #endregion

    #region parameters
    //[SerializeField] private float _sheepMaxSpeed = 6;
    //[SerializeField] private float _sheepAcceleration = 6;
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

    public Vector2 Movement() // M�todo que permite saber la direcci�n en la que est� mirando el jugador
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


    private void OnUp() // M�todo activado cada vez que el jugador introduce el input de saltar
    {
        if(_myRB.velocity.y < 0.1 && _myRC.ChoqueAbajo())
        {
            _currentFallSpeed = _jumpFallSpeed;
            _myRB.AddForce(Vector2.up * _currentJump, ForceMode2D.Impulse);
            //Llamada a la animaci�n de salto
            _myAnimationController.Salta();
        }
    }

    // M�todo que detecta cu�ndo el jugador ha soltado el bot�n de saltar
    // Nos permite hacer el salto m�s f�cil de controlar
    private void OnStopJumping() 
    {
        _currentFallSpeed = _fallSpeed;
        print("Jump stopped");
    }

    private void OnHorizontalMovement (InputValue value) 
    {
        _movementDirection = value.Get<Vector2>(); //Este vector siempre tendr� la forma (1, 0) o (-1, 0)
        if( _movementDirection != Vector2.zero )
        {
            _movementTracker = _movementDirection;
            _myAnimationController.Gira(_movementDirection.x);
        }
        
        //print($"Vector de la entrada: ({_movementDirection.x}, {_movementDirection.y})");

        //if ((movement.x < 0 && !choqueIzq) || (movement.x > 0 && !choqueDer)) // Por qu� hac�amos aqu� esta comprobaci�n aqu�?
        //{
        //    movementTracker = movement;
        //    _myAnimationController.Gira(movement.x);
        //    print("Bucle movimiento");
        //}


        //if (movement.x < 0 && !choqueIzq)
        //{
        //    movementTracker = movement;
        //}
        //else if (movement.x > 0 && !choqueDer)
        //{
        //    movementTracker = movement;
        //}
    }

    public void OvejaSoltada()
    {
        //Debug.Log("OvejaSoltada()");
        _currentJump = _jumpForce;
    }

    public void OvejaRecogida()
    {
        //Debug.Log("OvejaRecogida()");
        _currentJump = _sheepJumpForce;
    }

    private void Update () // �Hay alguna raz�n por la que hag�is este c�lculo en el FixedUpdate()? - R
    {
        //_currentSpeed = _maxSpeed;




        if (_movementDirection.x < 0 && !_myRC.ChoqueIzq() || _movementDirection.x > 0 && !_myRC.ChoqueDer())
        {
            _myRB.velocity = _movementDirection * _currentSpeed + Vector2.up * _myRB.velocity.y;

            //_myRB.velocity = Mathf.Lerp(Mathf.Abs(_myRB.velocity.x)/* * _movementDirection.x*/, _maxHorizontalSpeed/* * _movementDirection.x*/, 0.2f) * _movementDirection + Vector2.up * _myRB.velocity.y;
            _currentSpeed += _acceleration * Time.deltaTime;

            print($"Velocidad horizontal: {_myRB.velocity.x}");
        }
        else
        {
            _currentSpeed = _baseSpeed;
        }

        // Aplicamos la gravedad (tiene que ser manualmente para un mejor control del salto)
        _myRB.velocity += _currentFallSpeed * Vector2.down * Time.deltaTime;

        // Limitaci�n de las velocidades a los valores deseados
        _myRB.velocity = Mathf.Clamp(_myRB.velocity.x, -_maxSpeed, _maxSpeed) * Vector2.right 
                       + Mathf.Clamp(_myRB.velocity.y, -_maxFallSpeed, _maxVerticalSpeed) * Vector2.up;
    }


}
