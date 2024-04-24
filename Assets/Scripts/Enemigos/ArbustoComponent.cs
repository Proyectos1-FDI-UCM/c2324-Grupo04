using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbustoComponent : MonoBehaviour
{
    [SerializeField] private int _damage = -2;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Has chocado con un arbusto");
        if (other.GetComponent<GranjeroMovement>() != null)
        {
            Debug.Log("Eres un granjero");
            other.GetComponent<HealthComponent>().ChangeHealth(_damage);
        }
    }

    //public void OnCollisionEnter2D(Collision collision)
    //{
    //    Debug.Log("Has chocado con un arbusto");
    //    if (collision.gameObject.GetComponent<GranjeroMovement>() != null)
    //    {
    //        Debug.Log("Eres un granjero");
    //        collision.gameObject.GetComponent<HealthComponent>().ChangeHealth(_damage);
    //    }
    //}
}
