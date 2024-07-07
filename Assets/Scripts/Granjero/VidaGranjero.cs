using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La idea es que este script utilice el HealthComponent como vasallo, pero que maneje los eventos de muerte del granjero
/// Las llamadas de da�o y de vida del granjero quedan relegadas a �l
/// </summary>
public class VidaGranjero : MonoBehaviour
{
    #region references
    private HealthComponent _myHC;
    #endregion

    #region parameters
    private float _tiempInv = 0.8f;
    #endregion


    #region mehtods
    private void CambiaVidaGranjero(int incremento)
    {
        if (_myHC.ChangeHealth(incremento))
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Fin de la partida (jugador)");
        GameManager.Instance.ReiniciaEscena();
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myHC = GetComponent<HealthComponent>();
        _myHC.SetInvTime(_tiempInv);
    }
}
