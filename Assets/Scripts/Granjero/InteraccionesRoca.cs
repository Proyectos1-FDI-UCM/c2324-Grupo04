using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionesRoca : MonoBehaviour
{
    #region references
    private Transform _myTransform;
    private GranjeroMovement _granjeroMovement;
    private Transform _rocaTransform;
    private SpriteRenderer _rocaSR;
    private Rigidbody2D _rocaRB;
    private LanzaObjeto _lanzaObjeto;
    [SerializeField]
    private GameObject roca;
    private Roca _roca;
    #endregion


    #region parameters
    [SerializeField]
    private float _distanciaInteraccion = 2f;
    [SerializeField]
    private float _verticalOffset = 1f;
    [SerializeField]
    private float _velocidadRoca = 2f;
    [SerializeField]
    private float _deceleracionRoca = 0f;
    [SerializeField]
    private float _tiempoDeInercia = 0.8f;
    #endregion


    #region methods
    void Start()
    {
        _myTransform = transform;
        _granjeroMovement = GetComponent<GranjeroMovement>();
        _rocaTransform = GameManager.Instance.ReferenciaTransformRoca();
        _rocaSR = _rocaTransform.GetComponent<SpriteRenderer>();
        _rocaRB = _rocaTransform.GetComponent<Rigidbody2D>();
        _lanzaObjeto = GetComponent<LanzaObjeto>();
        _roca = roca.GetComponent<Roca>();
    }


    private void OnInteraction1()
    {
        if (!GameManager.Instance.cargandoOveja)
        {
            if (GameManager.Instance.cargandoRoca)
            {
                SueltaRoca();
                GameManager.Instance.SueltaRoca();
            }
            else if ((_rocaTransform.position - _myTransform.position).magnitude <= _distanciaInteraccion)
            {
                CogeRoca();
                GameManager.Instance.CogeRoca();
            }
        }

    }

    private void CogeRoca()
    {
        _rocaSR.enabled = false;
        _rocaRB.simulated = false;
    }

    private void SueltaRoca()
    {
        _rocaTransform.position = GameManager.Instance.PlayerPosition() + _verticalOffset * Vector3.up;
        _rocaSR.enabled = true;
        _rocaRB.simulated = true;

        Vector3 direccion;
        if (_granjeroMovement.Movement().x >= 0)
        {
            direccion = new Vector3(1, 0, 0);
        }
        else
        {
            direccion = new Vector3(-1, 0, 0);
        }

        //_roca.SueltaRoca();
        _lanzaObjeto.enabled = true;
        _lanzaObjeto.Lanza(_rocaTransform, _velocidadRoca, direccion, _deceleracionRoca, _tiempoDeInercia);
    }

    #endregion

}
