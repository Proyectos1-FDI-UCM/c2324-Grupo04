using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpComponent : MonoBehaviour
{
    public int valor = 1;
    public GameManager gameManager;



    
    void OnTriggerEnter2D(Collider2D collision) // Se activa cuando álgo colisiona con él
    {

        GranjeroMovement granjeroMovement = collision.GetComponent<GranjeroMovement>(); // Busca un componente del tipo GranjeroMovement

        if (granjeroMovement != null) // Comprueba que granjeroMovement existe (y por tanto que lo que ha chocado es el granjero)
        {
            gameManager.SumarObjetos(valor);
            Destroy(this.gameObject);
        }
    }
}
