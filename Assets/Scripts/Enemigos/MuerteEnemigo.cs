using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteEnemigo : MonoBehaviour
{
    public void Die()
    {
        //Llamada a la animación de muerte
        Destroy(gameObject);
    }
}
