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

    private void Salto()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * impulso);
        }
    }

    private void OnHorizontalMovement (InputValue value) 
    {
        movement = value.Get<Vector2>();
    }
   
    private void FixedUpdate ()
    {
        //Variante 1
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); //Sin aceleracion
       
        //variante 2 con aceleracion1   (se puede cambiar el linear drag)
        /*
        if (movement.x != 0){
            rb.velocity = movement * speed;
        }
        */

        //variante 3 con aceleracion2
        /*
         rb.AddForce(movement * speed);
         * */
    }
 

}
