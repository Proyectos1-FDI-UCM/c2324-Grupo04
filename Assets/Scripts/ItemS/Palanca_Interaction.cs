using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca_Interaction : MonoBehaviour
{
    public bool palancaActiva = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<GranjeroMovement>() != null)
        {
            if (palancaActiva)
            {
                Debug.Log("Palanca desactivada");
                palancaActiva = false;
            }
            else
            {
                Debug.Log("Palanca activada");
                palancaActiva = true;
            }
        }
    }
}
