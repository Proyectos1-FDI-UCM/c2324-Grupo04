using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La idea es que este script utilice el HealthComponent como vasallo, pero que maneje los eventos de muerte del granjero
/// Las llamadas de daño y de vida del granjero quedan relegadas a él
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
    public void CambiaVidaGranjero(int incremento)
    {
        if (_myHC.ChangeHealth(incremento))
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.Instance.ReiniciaEscena();
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myHC = GetComponent<HealthComponent>();
        _myHC.SetInvTime(_tiempInv);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
