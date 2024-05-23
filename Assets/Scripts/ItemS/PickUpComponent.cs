using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class PickUpComponent : MonoBehaviour // Este script está obsoleto - R
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
    /// 21 -> Receta trampolín
    /// El 30 es la oveja
    /// 30 -> Oveja
    ///</leyenda>
    
    //[SerializeField]
    //public GameManager.TipoObjeto _objeto; // Con un poco de suerte esto quedará obsoleto

    //void OnTriggerEnter2D(Collider2D collision) // Se activa cuando �lgo colisiona con �l
    //{

    //    GranjeroMovement granjeroMovement = collision.GetComponent<GranjeroMovement>(); // Busca un componente del tipo GranjeroMovement

    //    if (granjeroMovement != null) // Comprueba que granjeroMovement existe (y por tanto que lo que ha chocado es el granjero)
    //    {
    //        GameManager.Instance.RecogidaObjeto(_objeto);
    //        Destroy(gameObject);
    //    }
    //}
}
