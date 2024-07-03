using UnityEngine;

public class Señuelo : MonoBehaviour
{
    private float _duracionSeñuelo;
    private float _tiempoSeñuelo;

    private void Start()
    {
        _duracionSeñuelo = 5f; 
        _tiempoSeñuelo = 0f;
        GameManager.Instance.SeñueloCreado(transform);
    }

    private void Update()
    {
        _tiempoSeñuelo += Time.deltaTime;
        if (_tiempoSeñuelo > _duracionSeñuelo || GameManager.Instance.nseñuelo > 1)
        {
            Destruido();
        }
    }

    private void Destruido()
    {
        GameManager.Instance.SeñueloDestruido();
        Destroy(gameObject);
    }
}
