sing System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteJugador : MonoBehaviour
{
    public GameObject canvasMuerte;
    public void Die()
    {
        
        // Activar el Canvas de muerte
        canvasMuerte.SetActive(true);

    }
}
