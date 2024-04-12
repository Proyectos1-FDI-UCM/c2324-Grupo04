using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteJugador : MonoBehaviour
{
    public void Die()
    {
        GameManager.Instance.ReiniciaEscena();
        //Debug.Log("Fin de la partida");
    }
}
