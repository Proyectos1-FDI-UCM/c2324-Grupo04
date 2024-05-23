using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeComponent : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision) // Se activa cuando algo colisiona con él
    {
        GranjeroMovement granjeroMovement = collision.GetComponent<GranjeroMovement>(); // Busca un componente del tipo GranjeroMovement

        if (granjeroMovement != null) // Comprueba que granjeroMovement existe (y por tanto que lo que ha chocado es el granjero)
        {
            GameManager.Instance.PickUpRope();
            Destroy(gameObject);
        }
    }
}
