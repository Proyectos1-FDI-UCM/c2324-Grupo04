using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Señuelo : MonoBehaviour
{
    private Transform _myTransform;
    [SerializeField]
    private float duracionSeñuelo;
    private float tiempoSeñuelo;

    private void Destruido()
    {
        GameManager.Instance.SeñueloDestruido();
        Destroy(this.gameObject);
    }

    private void Die() // Método que llama a su acción de muerte (lo he sacado del HealthComponent al pie de la letra)
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
        if (tiempoSeñuelo > duracionSeñuelo)
        {
            Destruido();
        }
        if (GameManager.Instance.nseñuelo > 1)
        {
            Destruido();
        }
    }
}
