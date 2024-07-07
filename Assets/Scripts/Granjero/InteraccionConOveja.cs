using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionConOveja : MonoBehaviour // Componente perteneciente al jugador
{
    #region references
    private Transform _myTransform;
    private GranjeroMovement _granjeroMovement;
    private Transform _ovejaTransform;
    private SpriteRenderer _ovejaSR;
    private Rigidbody2D _ovejaRB;
    private LanzaObjeto _lanzaObjeto;
    private MovimientoOveja _movimientoOveja;
    #endregion


    #region parameters
    [SerializeField]
    private float _distanciaInteraccion = 2f;
    [SerializeField]
    private float _verticalOffset = 1f;
    [SerializeField]
    private float _velocidadOveja = 2f;
    [SerializeField]
    private float _deceleracionOveja = 0f;
    [SerializeField]
    private float _tiempoDeInercia = 0.8f;
    #endregion


    #region methods
    void Start()
    {
        _myTransform = transform;
        _granjeroMovement = GetComponent<GranjeroMovement>();
        _ovejaTransform = GameManager.Instance.ReferenciaTransformOveja();
        _ovejaSR = _ovejaTransform.GetComponent<SpriteRenderer>();
        _ovejaRB = _ovejaTransform.GetComponent<Rigidbody2D>();
        _lanzaObjeto = GetComponent<LanzaObjeto>();
        _movimientoOveja = GameManager.Instance.ReferenciaMovimientoOveja();
    }


    private void OnInteraction1() // Método que se activa al recoger la oveja con la e
    {
        if (GameManager.Instance.cargandoOveja)
        {
            SueltaOveja();
            GameManager.Instance.SueltaOveja();
        }
        else if ((_ovejaTransform.position - _myTransform.position).magnitude <= _distanciaInteraccion)
        {
            CogeOveja();
            GameManager.Instance.CogeOveja();
        }
    }

    private void CogeOveja()
    {
        // Llamar a la animación de recogida de la oveja del granjero

        // Desactivación del sprite de la oveja
        _ovejaSR.enabled = false;
        // Desactivación del rigidbody de la oveja
        _ovejaRB.simulated = false;
        _movimientoOveja.CogeOveja();
    }

    private void SueltaOveja()
    {
        // Llamar a la animación de soltar la oveja del granjero

        _ovejaTransform.position = GameManager.Instance.PlayerPosition() + _verticalOffset * Vector3.up;
        _ovejaSR.enabled = true;
        _ovejaRB.simulated = true;

        Vector3 direccion;
        if (_granjeroMovement.Movement().x >= 0)
        {
            direccion = new Vector3(1, 0, 0);
        }
        else
        {
            direccion = new Vector3(-1, 0, 0);
        }

        _lanzaObjeto.enabled = true;
        _lanzaObjeto.Lanza(_ovejaTransform, _velocidadOveja, direccion, _deceleracionOveja, _tiempoDeInercia);
        _movimientoOveja.SueltaOveja(direccion.x);
    }

    #endregion

}
