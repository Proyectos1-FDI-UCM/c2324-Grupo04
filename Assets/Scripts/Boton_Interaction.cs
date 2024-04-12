using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boton_Interaction : MonoBehaviour
{
    public bool botonActivo = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<GranjeroMovement>() != null || collision.GetComponent<OvejaBalido>() != null || collision.GetComponent<BloqueMovible>())
        {
            Debug.Log("Botón pulsado");
            botonActivo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.GetComponent<GranjeroMovement>() != null || collision.GetComponent<OvejaBalido>() != null || collision.GetComponent<BloqueMovible>())
        {
            Debug.Log("Botón soltado");
            botonActivo = false;
        }
    }
}
