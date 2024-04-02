using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class PickUpComponent : MonoBehaviour
{
    ///<leyenda>
    /// 0 -> Cuerda
    /// 1 -> Moneda
    /// 2 -> Vida
    /// 3 -> Aumento de la vida m�xima
    /// A partir del 10 son armas
    /// 10 -> Horca
    /// 11 -> Pala
    /// A partir del 20 son recetas
    /// 20 -> Receta señuelo
    /// 21 -> Receta trampol�n
    /// El 30 es la oveja
    /// 30 -> Oveja
    ///</leyenda>
    
    [SerializeField]
    public GameManager.TipoObjeto _objeto;
    private int value = 1;

    void OnTriggerEnter2D(Collider2D collision) // Se activa cuando �lgo colisiona con �l
    {

        GranjeroMovement granjeroMovement = collision.GetComponent<GranjeroMovement>(); // Busca un componente del tipo GranjeroMovement

        if (granjeroMovement != null) // Comprueba que granjeroMovement existe (y por tanto que lo que ha chocado es el granjero)
        {
            GameManager.Instance.RecogidaObjeto(_objeto);
            Destroy(gameObject);
        }
    }
}
