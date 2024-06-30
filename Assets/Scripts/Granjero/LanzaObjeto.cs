using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzaObjeto : MonoBehaviour
{
    #region references
    private Transform _myTransform;
    private Transform _objeto;
    #endregion


    #region parameters
    private float _velocidad = 1f;
    private Vector3 _direccion = Vector3.right;
    private float _deceleracion = 0f;
    private float _tiempo = 1f;
    #endregion


    #region variables
    private float _cont = 0f;
    #endregion








    #region methods

    void Start()
    {
        _myTransform = transform;
        this.enabled = false;
    }

    void Update()
    {
        if (_cont >= _tiempo)
        {
            _cont = 0f;
            Fin();
        }
        else
        {
            _objeto.position += _direccion * _velocidad * Time.deltaTime;
            _velocidad -= _deceleracion * Time.deltaTime;
            _cont += Time.deltaTime;
        }
    }

    public void Lanza(Transform referencia, float velocidad, Vector3 direccion, float deceleracion, float tiempo)
    {
        _objeto = referencia;
        _velocidad = velocidad;
        _direccion = direccion.normalized;
        _deceleracion = deceleracion;
        _tiempo = tiempo;
        //print("objeto lanzado");
    }

    private void ReferenciaObjeto(Transform referencia) // En principio no se necesita
    {
        _objeto = referencia;
    }

    private void Fin()
    {
        this.enabled = false;
    }

    #endregion
}
