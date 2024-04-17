using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_ObjetosActivadosPorBotón : MonoBehaviour
{
    [SerializeField] private GameObject boton;
    [SerializeField] private bool esPlataformaMovil;
    [SerializeField] private bool esPuerta;
    private PlatformMovement movimientoPlataforma;
    private BoxCollider2D collider;
    bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        if (esPlataformaMovil)
        {
            movimientoPlataforma = GetComponent<PlatformMovement>(); ;
        }
        if (esPuerta)
        {
            collider = GetComponent<BoxCollider2D>(); ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isPressed = boton.GetComponent<Boton_Interaction>().botonActivo;
        if (esPlataformaMovil)
        {
            if (isPressed)
            {
                movimientoPlataforma.enabled = true;
            }
            else
            {
                movimientoPlataforma.enabled = false;
            }
        }

        if (esPuerta)
        {
            if (isPressed)
            {
                collider.enabled = false;
            }
            else
            {
                collider.enabled = true;
            }
        }
    }
}
