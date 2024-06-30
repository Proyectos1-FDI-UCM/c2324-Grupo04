using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RompeBloques : MonoBehaviour
{
    private float rayDistance = 1.0f; // Distancia del rayo para detectar bloques
    [SerializeField] private LayerMask blockLayer; // Capa de los bloques que se pueden romper
    [SerializeField] private bool lookRight = true;

    void Update()
    {
        if (Input.GetKeyDown("p")) // Cambia "E" por la tecla que desees usar
        {
            BreakBlock();
        }
        if (Input.GetKeyDown("d"))
        {
            lookRight = true;
        } else if (Input.GetKeyDown("a"))
        {
            lookRight = false;
        }
    }

    void BreakBlock()
    {
         // Dirección hacia la que está mirando el jugador
        Vector2 directionRight = Vector2.right;
        Vector2 directionLeft = Vector2.left;
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, directionRight, rayDistance, blockLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, directionLeft, rayDistance, blockLayer);
    
        if (hitRight.collider != null && lookRight == true)
        {
            Destroy(hitRight.collider.gameObject);
        } 
        else if (hitLeft.collider != null && lookRight == false)
        {
            Destroy(hitLeft.collider.gameObject);
        }
    }
}
