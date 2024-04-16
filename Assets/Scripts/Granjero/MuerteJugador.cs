using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteJugador : MonoBehaviour
{
    //public GameObject canvasMuerte;

    public void Die()
    {
        GameManager.Instance.ReiniciaEscena();
        /* canvasMuerte.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("El jugador ha muerto.");
        */
    }
}
