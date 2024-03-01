using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbustoComponent : MonoBehaviour
{
    [SerializeField] private int _damage = -2;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Has chocado con un arbusto");
        if (other.GetComponent<GranjeroMovement>() != null)
        {
            Debug.Log("Eres un granjero");
            other.GetComponent<HealthComponent>().ChangeHealth(_damage);
        }
    }
}
