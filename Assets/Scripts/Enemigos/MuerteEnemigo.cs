using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteEnemigo : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionPrefab;

    public void Die()
    {
        //Llamada a la animación de muerte
        GameObject animation = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(animation, 1.5f);
        Destroy(gameObject);
    }
}
