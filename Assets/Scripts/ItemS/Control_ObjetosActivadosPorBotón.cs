using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_ObjetosActivadosPorBotón : MonoBehaviour
{
    [SerializeField] private GameObject activador1;
    [SerializeField] private GameObject activador2;
    [SerializeField] private bool usaBoton;
    [SerializeField] private bool usaPalanca;
    [SerializeField] private bool esPlataformaMovil;
    [SerializeField] private bool esPuerta;
    private PlatformMovement movimientoPlataforma;
    private Door_Behavior comportamientoPuerta;
    private bool setActive1;
    private bool setActive2;

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
            setActive1 = activador1.GetComponent<Boton_Interaction>().botonActivo;
            setActive2 = activador2.GetComponent<Boton_Interaction>().botonActivo;
        }
        else if (usaPalanca)
        {
            setActive1 = activador1.GetComponent<Palanca_Interaction>().palancaActiva;
        }

        if (esPlataformaMovil)
        {
            if (setActive1 || setActive2)
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
            if (setActive1)
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
