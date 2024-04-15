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

    private Vector2 movement;
    
    private float Horizontal;
    public Vector2 movementTracker;
    private float speed;
    private float impulso;

    #region parameters
    [SerializeField] private float _velocidadOveja = 3;
    [SerializeField] private float _impulsoOveja = 3;
    [SerializeField] private float _velocidadInicial = 3;
    [SerializeField] private float _impulsoInicial = 3;
    [SerializeField] private float _fallSpeed = 4;
    #endregion

    #region variables
    public bool choqueAbajo;
    public bool choqueIzq;
    public bool choqueDer;
    //public bool allowLadder; // No vamos a usar la escalera ya
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
        speed = _velocidadInicial;
        impulso = _impulsoInicial;
        _myAnimationController = GetComponent<GranjeroAnimationController>();
        _myRB = GetComponent<Rigidbody2D>();
        _myRC = GetComponent<Player_Raycast>();
    }


    private void  OnUp()
    {
        Debug.Log("Salto");
        if(_myRB.velocity.y < 0.1 && choqueAbajo)
        {
            _myRB.AddForce(Vector2.up * impulso, ForceMode2D.Impulse);
            //Llamada a la animación de salto
            _myAnimationController.Salta();
        }
    }

    private void OnHorizontalMovement (InputValue value) 
    {
        movement = value.Get<Vector2>();
        if ((movement.x < 0 && !choqueIzq) || (movement.x > 0 && !choqueDer))
        {
            movementTracker = movement;
            _myAnimationController.Gira(movement.x);
        }

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
        speed = _velocidadInicial;
        impulso = _impulsoInicial;
    }

    public void OvejaRecogida()
    {
        //Debug.Log("OvejaRecogida()");
        speed = _velocidadOveja;
        impulso = _impulsoOveja;
    }

    private void FixedUpdate () // ¿Hay alguna razón por la que hagáis este cálculo en el FixedUpdate()? - R
    {
        //Variante 1
        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); //Sin aceleracion

        //variante 2 con aceleracion1   (se puede cambiar el linear drag)

        if ((movement.x < 0 && !choqueIzq) || (movement.x > 0 && !choqueDer))
        {
            _myRB.velocity = movement * speed + Vector2.up * _myRB.velocity.y;
        }
        if (_myRB.velocity.y < -_fallSpeed)
        {
            _myRB.velocity = new Vector2(_myRB.velocity.x, -_fallSpeed);
        }
        //variante 3 con aceleracion2
        /*
         rb.AddForce(movement * speed);
         * */
    }


}
