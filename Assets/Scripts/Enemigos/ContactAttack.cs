using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactAttack : MonoBehaviour
{
    [SerializeField] private int damage = -1;

    // De esta manera se le puede aplicar a todos los objetos, sea su collider trigger o no
    void OnTriggerStay2D(Collider2D collision)
    {
        ApplyDamage(collision.gameObject);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        ApplyDamage(collision.gameObject);
    }

    // Método auxiliar que comprueba si es el jugador o la oveja y en caso de que sí le aplica el daño
    private void ApplyDamage(GameObject collision)
    {
        if ((collision.GetComponent<GranjeroMovement>() != null) || (collision.GetComponent<MovimientoOveja>() != null) || (collision.GetComponent<Señuelo>() != null))
        {
            collision.GetComponent<HealthComponent>().ChangeHealth(damage);
        }
    }
}
