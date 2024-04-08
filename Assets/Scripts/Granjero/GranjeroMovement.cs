using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GranjeroMovement : MonoBehaviour
{
    private Vector2 movement;
    public Rigidbody2D rb;
    private float Horizontal;
    public Vector2 movementTracker;
    private int speed;
    private float impulso;


    [SerializeField] private int _velocidadOveja = 3;
    [SerializeField] private float _impulsoOveja = 3;
    [SerializeField] private int _velocidadInicial = 3;
    [SerializeField] private float _impulsoInicial = 3;
    [SerializeField] private float velCaida = 0;
    [SerializeField] private float ladderSpeed = 2;
    private GranjeroAnimationController _myAnimationController;

    
    public bool choqueAbajo;
    public bool choqueIzq;
    public bool choqueDer;
    public bool allowLadder;

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
    public void SetBoolLadder(bool value)
    {
        allowLadder = value;
    }

    public Vector2 Movement()
    {
        return movementTracker;
    }




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        speed = _velocidadInicial;
        impulso = _impulsoInicial;
        _myAnimationController = GetComponent<GranjeroAnimationController>();
    }


    private void  OnUp()
    {
        Debug.Log("Salto");
        if(rb.velocity.y < 0.1 && choqueAbajo && !allowLadder)
        {
            rb.AddForce(Vector2.up * impulso, ForceMode2D.Impulse);
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

    private void OnLadder(InputValue value)
    {
        Debug.Log(value.ToString());
        if (allowLadder)
        {
            Vector2 stairMovement = value.Get<Vector2>();
            if (stairMovement.x < 0 || stairMovement.x > 0)
            {
                Vector2 vertical = new Vector2(rb.velocity.x, stairMovement.x);
                rb.velocity = vertical;
            }

        }
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

    private void FixedUpdate ()
    {
        //Variante 1
        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); //Sin aceleracion

        //variante 2 con aceleracion1   (se puede cambiar el linear drag)

        if ((movement.x < 0 && !choqueIzq) || (movement.x > 0 && !choqueDer))
        {
            rb.velocity = movement * speed + Vector2.up * rb.velocity.y;
        }
        if (rb.velocity.y < -velCaida)
        {
            rb.velocity = new Vector2(rb.velocity.x, -velCaida);
        }
        //variante 3 con aceleracion2
        /*
         rb.AddForce(movement * speed);
         * */
    }


}
