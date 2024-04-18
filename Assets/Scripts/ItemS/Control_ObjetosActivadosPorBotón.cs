using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_ObjetosActivadosPorBotón : MonoBehaviour
{
    [SerializeField] private GameObject activador;
    [SerializeField] private bool usaBoton;
    [SerializeField] private bool usaPalanca;
    [SerializeField] private bool esPlataformaMovil;
    [SerializeField] private bool esPuerta;
    private PlatformMovement movimientoPlataforma;
    private Door_Behavior comportamientoPuerta;
    private bool setActive;

    // Start is called before the first frame update
    void Start()
    {
        if (esPlataformaMovil)
        {
            movimientoPlataforma = GetComponent<PlatformMovement>(); ;
        }
        if (esPuerta)
        {
            comportamientoPuerta = GetComponent<Door_Behavior>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (usaBoton)
        {
            setActive = activador.GetComponent<Boton_Interaction>().botonActivo;
        }
        else if (usaPalanca)
        {
            setActive = activador.GetComponent<Palanca_Interaction>().palancaActiva;
        }

        if (esPlataformaMovil)
        {
            if (setActive)
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
            if (setActive)
            {
                comportamientoPuerta.Open();
            }
            else
            {
                comportamientoPuerta.Close();
            }
        }
    }
}
