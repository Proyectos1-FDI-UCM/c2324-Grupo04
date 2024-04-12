using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_ObjetosActivadosPorBotón : MonoBehaviour
{
    [SerializeField] private GameObject boton;
    [SerializeField] private bool esPlataformaMovil;
    [SerializeField] private bool esPuerta;


    // Start is called before the first frame update
    void Start()
    {
        if (esPlataformaMovil)
        {
            movimientoPlataforma = _myPlatformMovement;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
