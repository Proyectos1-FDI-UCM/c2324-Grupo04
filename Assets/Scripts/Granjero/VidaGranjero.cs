using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaGranjero : MonoBehaviour
{
    private HealthComponent _healthComponent;
    private float _tiempInvulnerabilidad = 0.8f;

    private void Start()
    {
        _healthComponent = GetComponent<HealthComponent>();
        _healthComponent.SetInvTime(_tiempInvulnerabilidad);
    }

    public void CambiaVidaGranjero(int incremento)
    {
        if (_healthComponent.ChangeHealth(incremento))
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Fin de la partida (jugador)");
        GameManager.Instance.ReiniciaEscena();
    }
}
