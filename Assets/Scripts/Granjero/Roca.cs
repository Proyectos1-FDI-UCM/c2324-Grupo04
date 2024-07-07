using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roca : MonoBehaviour
{
    [SerializeField] private int damage = -10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
            if (collision.gameObject.GetComponent<EnemyMovement>())
            {
                collision.gameObject.GetComponent<HealthComponent>().ChangeHealth(damage);
            }
    }
}
