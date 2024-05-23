using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHealthIncrementComponent : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private int _healthIncrement = 2;
    [SerializeField]
    private int _maxHealthIncrement = 0;
    #endregion
    void OnTriggerEnter2D(Collider2D collision) // Se activa cuando algo colisiona con él
    {
        GranjeroMovement granjeroMovement = collision.GetComponent<GranjeroMovement>(); // Busca un componente del tipo GranjeroMovement

        if (granjeroMovement != null) // Comprueba que granjeroMovement existe (y por tanto que lo que ha chocado es el granjero)
        {
            HealthComponent _sheppHealth = GameManager.Instance.SheepsHealthComponent();
            _sheppHealth.ChangeHealth(_healthIncrement);
            _sheppHealth.ChangeMaxHealth(_maxHealthIncrement);
            Destroy(gameObject);
        }
    }
}
