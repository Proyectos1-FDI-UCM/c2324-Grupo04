using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GranjeroMovement : MonoBehaviour
{
    #region references
    private GranjeroAnimationController _myAnimationController;
    private Rigidbody2D _myRB; // Esto estaba público por alguna razón? - R
    private Player_Raycast _myRC;
    #endregion

    

    public Vector2 movementTracker;
    private float _maxHorizontalSpeed;

    #region parameters
    [SerializeField] private float _sheepMaxSpeed = 6;
    [SerializeField] private float _sheepAcceleration = 6;
    [SerializeField] private float _sheepJumpForce = 18;
    [SerializeField] private float _maxSpeed = 6;
    [SerializeField] private float _acceleration = 6;
    [SerializeField] private float _jumpForce = 24;
    [SerializeField] private float _fallSpeed = 4;
    [SerializeField] private float _maxFallSpeed = 4;
    [SerializeField] private float _maxVerticalSpeed = 30;
    #endregion

    #region variables
    private Vector2 _movementDirection;


    public bool choqueAbajo;
    public bool choqueIzq;
    public bool choqueDer;
    //public bool allowLadder; // No vamos a usar la escalera ya
    private float _currentSpeed = 0f;
    #endregion

    public void SetBoolDown(bool value)
    {
        choqueAbajo = value;
    }
    public void SetBoolLeft(bool value)
    {
        choqueIzq = value;
    }
    public void SetBoolRight(bool value)
    {
        choqueDer = value;
    }
    //public void SetBoolLadder(bool value)
    //{
    //    allowLadder = value;
    //}

    public Vector2 Movement()
    {
        return movementTracker;
    }

    private void Start()
    {
        _maxHorizontalSpeed = _maxSpeed;
        _maxFallSpeed = _jumpForce;
        _myAnimationController = GetComponent<GranjeroAnimationController>();
        _myRB = GetComponent<Rigidbody2D>();
        _myRC = GetComponent<Player_Raycast>();
    }


    private void  OnUp()
    {
        //Debug.Log("Salto");
        if(_myRB.velocity.y < 0.1 && choqueAbajo)
        {
            _myRB.AddForce(Vector2.up * _maxFallSpeed, ForceMode2D.Impulse);
            //Llamada a la animación de salto
            _myAnimationController.Salta();
        }
    }

    private void OnHorizontalMovement (InputValue value) 
    {
        _movementDirection = value.Get<Vector2>(); //Este vector siempre tendrá la forma (1, 0) o (-1, 0)
        movementTracker = _movementDirection;
        _myAnimationController.Gira(_movementDirection.x);
        print($"Vector de la entrada: ({_movementDirection.x}, {_movementDirection.y})");

        //if ((movement.x < 0 && !choqueIzq) || (movement.x > 0 && !choqueDer)) // Por qué hacíamos aquí esta comprobación aquí?
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
        _maxHorizontalSpeed = _maxSpeed;
        _maxFallSpeed = _jumpForce;
    }

    public void OvejaRecogida()
    {
        //Debug.Log("OvejaRecogida()");
        _maxHorizontalSpeed = _sheepMaxSpeed;
        _maxFallSpeed = _sheepJumpForce;
    }

    private void FixedUpdate () // ¿Hay alguna razón por la que hagáis este cálculo en el FixedUpdate()? - R
    {
        //Variante 1
        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); //Sin aceleracion

        //variante 2 con aceleracion1   (se puede cambiar el linear drag)

        //if ((movement.x < 0 && !choqueIzq) || (movement.x > 0 && !choqueDer))
        //{
        //    _myRB.velocity = movement * speed + Vector2.up * _myRB.velocity.y;
        //}
        //if (_myRB.velocity.y < -_fallSpeed)
        //{
        //    _myRB.velocity = new Vector2(_myRB.velocity.x, -_fallSpeed);
        //}

        // Versión con velocidad clampeada y aceleración progresiva - R

        float horizontalVel = Mathf.Clamp(_myRB.velocity.x, -_maxHorizontalSpeed, _maxHorizontalSpeed);
        float verticalVel = Mathf.Clamp(_myRB.velocity.y, -_maxFallSpeed, _maxVerticalSpeed);
        if ((_movementDirection.x < 0 && !choqueIzq) || (_movementDirection.x > 0 && !choqueDer))
        {
            _myRB.velocity = _movementDirection * _maxHorizontalSpeed + Vector2.up * _myRB.velocity.y;
        }
        if (_myRB.velocity.y < -_fallSpeed)
        {
            _myRB.velocity = new Vector2(_myRB.velocity.x, -_fallSpeed);
        }
        _myRB.velocity = Mathf.Clamp(_myRB.velocity.x, -_maxHorizontalSpeed, _maxHorizontalSpeed) * Vector2.right + Mathf.Clamp(_myRB.velocity.y, -_maxFallSpeed, _maxVerticalSpeed) * Vector2.up;
        //_myRB.velocity = horizontalVel * Vector2.right + verticalVel * Vector2.up;
        //variante 3 con aceleracion2
        /*
         rb.AddForce(movement * speed);
         * */
    }


}
