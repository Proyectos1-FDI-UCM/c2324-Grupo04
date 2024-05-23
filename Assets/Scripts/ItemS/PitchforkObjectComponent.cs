using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchforkObjectComponent : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) // Se activa cuando algo colisiona con él
    {
        HorcaAttack _horcaAttack = collision.GetComponent<HorcaAttack>(); // Busca un componente del tipo Create

        if (_horcaAttack != null) // Comprueba que granjeroMovement existe (y por tanto que lo que ha chocado es el granjero)
        {
            UIManager.Instance.PitchforkPickedUp();
            _horcaAttack.ActivatePitchfork();
            Destroy(gameObject);
        }
    }
}
