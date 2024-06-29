using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_ObjetosActivadosPorBotón : MonoBehaviour
{
    [SerializeField] private GameObject activador1;
    [SerializeField] private GameObject activador2;
    [SerializeField] private bool usaBoton;
    [SerializeField] private bool usaPalanca;
    [SerializeField] private bool esPlataformaMovilPorBoton;
    [SerializeField] private bool esPuerta;
    private PlatformMovement movimientoPlataforma;
    private Door_Behavior comportamientoPuerta;
    public bool setActive1;
    public bool setActive2;
    // NUEVAS VARIABLES
    [SerializeField] private bool usaPeso;

    // Start is called before the first frame update
    void Start()
    {
        if (esPlataformaMovilPorBoton)
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
        if (usaBoton || usaPeso)
        {
            setActive1 = activador1.GetComponent<Boton_Interaction>().botonActivo;
            setActive2 = activador2.GetComponent<Boton_Interaction>().botonActivo;
        }
        else if (usaPalanca)
        {
            setActive1 = activador1.GetComponent<Palanca_Interaction>().palancaActiva;
        }

        if (esPlataformaMovilPorBoton)
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
