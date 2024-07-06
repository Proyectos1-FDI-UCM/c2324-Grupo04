using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Señuelo : MonoBehaviour
{
    private Transform _myTransform;
    [SerializeField]
    private float duracionSeñuelo;
    private float tiempoSeñuelo;

    private void Die()
    {
        GameManager.Instance.SeñueloDestruido();
        Destroy(this.gameObject);
    }

    void Start()
    {
        _myTransform = transform;
        tiempoSeñuelo = 0f;
        GameManager.Instance.SeñueloCreado(_myTransform);
    }

    void Update()
    {
        tiempoSeñuelo += Time.deltaTime;
            if (tiempoSeñuelo > duracionSeñuelo || GameManager.Instance.nseñuelo > 1)
        if (tiempoSeñuelo > duracionSeñuelo || GameManager.Instance.nseñuelo > 1)
        {
            Die();
        }
    }
}
