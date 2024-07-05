using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    #region references
    private HealthComponent _myHC;
    #endregion

    #region parameters
    private float _tiempInv = 0.8f;
    #endregion


    #region mehtods
    public void CambiaVidaOveja(int incremento)
    {
        if (_myHC.ChangeHealth(incremento))
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myHC = GetComponent<HealthComponent>();
        _myHC.SetInvTime(_tiempInv);
    }
}
