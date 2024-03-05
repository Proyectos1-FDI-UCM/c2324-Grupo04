using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GranjeroMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;
    private float Horizontal;
    public Vector2 movementTracker;
    private int speed;
    private float impulso;


    [SerializeField] private int _velocidadOveja = 3;
    [SerializeField] private float _impulsoOveja = 3;
    [SerializeField] private int _velocidadInicial = 3;
    [SerializeField] private float _impulsoInicial = 3;
    [SerializeField] private float velCaida = 0;

    
    private bool choqueAbajo;
    private bool choqueIzq;
    private bool choqueDer;

    public void SetBoolDown(bool value)
    {
        choqueAbajo = value;
    }
    public void SetBoolLeft(bool value)
    {
        choqueAbajo = value;
    }
    public void SetBoolRight(bool value)
    {
        choqueAbajo = value;
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
    }


    private void  OnUp()
    {
        Debug.Log("Salto");
        if(rb.velocity.y < 0.1)// && choqueAbajo)
        {
            rb.AddForce(Vector2.up * impulso, ForceMode2D.Impulse);
        }
    }

    private void OnHorizontalMovement (InputValue value) 
    {
        movement = value.Get<Vector2>();
        if((movement.x < 0 && !choqueIzq) || (movement.x > 0 && !choqueDer))
        {
            movementTracker = movement;
        }
    }

    public void OvejaSoltada()
    {
        speed = _velocidadInicial;
        impulso = _impulsoInicial;
    }

    public void OvejaRecogida()
    {
        speed = _velocidadOveja;
        impulso = _impulsoOveja;
    }

    private void FixedUpdate ()
    {
        //Variante 1
        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); //Sin aceleracion

        //variante 2 con aceleracion1   (se puede cambiar el linear drag)

        if (movement.x != 0){
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
