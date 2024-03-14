using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Señuelo : MonoBehaviour
{
    private Transform _myTransform;
    [SerializeField]
    private float duracionSeñuelo;
    private float _duracionSeñuelo;

    public void Destruido()
    {
        GameManager.Instance.SeñueloDestruido();
        Destroy(this.gameObject);
    }

    void Start()
    {
        _myTransform = transform;
        _duracionSeñuelo = 0f;
        GameManager.Instance.SeñueloCreado(_myTransform);
    }

    void Update()
    {
        _duracionSeñuelo += Time.deltaTime;
        if (_duracionSeñuelo > duracionSeñuelo)
        {
            Destruido();
        }
        if (GameManager.Instance.nseñuelo > 1)
        {
            Destruido();
        }
    }
}
