using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Señuelo : MonoBehaviour
{
    private Transform _myTransform;
    [SerializeField]
    private float duracionSeñuelo;
    private float _duracionSeñuelo;
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
            GameManager.Instance.SeñueloDestruido();
            Destroy(this.gameObject);
        }
    }
}
