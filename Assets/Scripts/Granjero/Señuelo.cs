using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Señuelo : MonoBehaviour
{
    [SerializeField]
    private float duracionSeñuelo;
    private float _duracionSeñuelo;
    void Start()
    {
        _duracionSeñuelo = 0f;   
    }

    void Update()
    {
        _duracionSeñuelo += Time.deltaTime;
        if (_duracionSeñuelo > duracionSeñuelo)
        {
            Destroy(this.gameObject);
        }
    }
}
