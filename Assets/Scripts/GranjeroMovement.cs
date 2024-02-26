using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GranjeroMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;
    private float Horizontal;

    [SerializeField] private int speed = 3;
    [SerializeField] private float impulso = 3;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void  OnUp()
    {
        Debug.Log("Salto");
        
            rb.AddForce(Vector2.up * impulso, ForceMode2D.Impulse);

    }
    private void Update()
    {
        
    }

    private void OnHorizontalMovement (InputValue value) 
    {
        movement = value.Get<Vector2>();
    }
   
    private void FixedUpdate ()
    {
        //Variante 1
        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); //Sin aceleracion
       
        //variante 2 con aceleracion1   (se puede cambiar el linear drag)
        
        if (movement.x != 0){
            rb.velocity = movement * speed + Vector2.up * rb.velocity.y;
        }
        

        //variante 3 con aceleracion2
        /*
         rb.AddForce(movement * speed);
         * */
    }
 

}
