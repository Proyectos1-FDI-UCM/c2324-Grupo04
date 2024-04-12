using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Create : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject Trampoline;

    [SerializeField]
    private GameObject Señuelo;
    private Transform _myTransform;
    private GranjeroAnimationController _myAnimationController;
    private GranjeroMovement _playerMovement;
    private LanzaObjeto _lanzaObjeto;

    #endregion


    #region parameters
    //[SerializeField]
    //private float _tacoste = 1; // Nunca se usa así que lo comento
    //[SerializeField]
    //private float _secoste = 0;  // Nunca se usa así que lo comento
    [SerializeField]
    private float _horizontalOffset = 1;
    /*// He intentado usar el LanzaObjeto para solucionar los problemas de instanciación, pero no he podido
    private float _verticalOffset = 1;
    [SerializeField]
    private float _velocidad = 4;
    [SerializeField]
    private float _tiempoInercia = 0.6f; // Tiempo que se mueve el objeto después de lanzarlo
    [SerializeField]
    private float _umbralInercia = 1f; // Umbral de multiplicador de velocidad mínima a partir del cual se tiene en cuenta la velocidad para el lanzamiento*/

    #endregion


    #region variables
    private bool _puedeTrampolin = false;
    private bool _puedeSeñuelo = false;
    #endregion


    

    private void OnAction2()
    {
        if (_puedeTrampolin && GameManager.Instance.ObtenerCuerdas() > 0 && _playerMovement.choqueAbajo) 
        {
            //Llamada a la animación
            _myAnimationController.SueltaObjeto();

            Vector2 spawnPos;
            if (_playerMovement.Movement().x < 0 && !_playerMovement.choqueIzq)
            {
                spawnPos = new Vector2(_myTransform.position.x - _horizontalOffset, _myTransform.position.y);
                GameObject trampolin = Instantiate(Trampoline, spawnPos, Quaternion.identity);
                GameManager.Instance.ChangeCantidadCuerda(-1);
                HudManager.instance.UpdateCuerda(1);
            }
            else if (_playerMovement.Movement().x >= 0 && !_playerMovement.choqueDer) // Esta condición es necesaria para asegurarnos de no instanciar algo en una pared
            {
                spawnPos = new Vector2(_myTransform.position.x + _horizontalOffset, _myTransform.position.y);
                GameObject trampolin = Instantiate(Trampoline, spawnPos, Quaternion.identity);
                GameManager.Instance.ChangeCantidadCuerda(-1);
                HudManager.instance.UpdateCuerda(1);
            }
            /*// He intentado usar el LanzaObjeto para solucionar los problemas de instanciación, pero no he podido
            Transform trampolin = Instantiate(Trampoline, _myTransform.position + _verticalOffset * Vector3.up, Quaternion.identity).transform;
            float compHoriz = _playerMovement.Movement().x;
            if (Mathf.Abs(compHoriz) < _umbralInercia)
            {
                _lanzaObjeto.Lanza(trampolin, _velocidad, new Vector3(compHoriz / Mathf.Abs(compHoriz), 0, 0), 0f, _tiempoInercia);
            }
            else
            {
                _lanzaObjeto.Lanza(trampolin, _velocidad, new Vector3(compHoriz, 0, 0), 0f, _tiempoInercia);
            }
            //print("Dirección: " + _playerMovement.Movement().x)
            GameManager.Instance.ChangeCantidadCuerda(-1);
            HudManager.instance.UpdateCuerda(1);
            */
        }
    }

    private void CreaSeñuelo() // Método auxiliar para no copiar y pegar código en el if-else if
    {

    }

    private void OnAction3()
    {
        if (_puedeSeñuelo && GameManager.Instance.ObtenerCuerdas() > 0 && _playerMovement.choqueAbajo) 
        {
            //Llamada a la animación
            _myAnimationController.SueltaObjeto();

            Vector2 spawnPos;
            if (_playerMovement.Movement().x < 0 && !_playerMovement.choqueIzq)
            {
                spawnPos = new Vector2(_myTransform.position.x - _horizontalOffset, _myTransform.position.y);
                GameManager.Instance.nseñuelo++;
                GameObject señuelo = Instantiate(Señuelo, spawnPos, Quaternion.identity);
                //Debug.Log("Señuelo");
                GameManager.Instance.ChangeCantidadCuerda(-1);
                HudManager.instance.UpdateCuerda(1);
            }
            else if (_playerMovement.Movement().x >= 0 && !_playerMovement.choqueDer)  // Esta condición es necesaria para asegurarnos de no instanciar algo en una pared
            {
                spawnPos = new Vector2(_myTransform.position.x + _horizontalOffset, _myTransform.position.y);
                GameManager.Instance.nseñuelo++;
                GameObject señuelo = Instantiate(Señuelo, spawnPos, Quaternion.identity);
                //Debug.Log("Señuelo");
                GameManager.Instance.ChangeCantidadCuerda(-1);
                HudManager.instance.UpdateCuerda(1);
            }

            
        }
    }

    public void ActivaTrampolin()
    {
        _puedeTrampolin = true;
    }

    public void ActivaSeñuelo()
    {
        _puedeSeñuelo = true;
    }

    private void Start()
    {
        _myTransform = transform;
        _playerMovement = GetComponent<GranjeroMovement>();
        _myAnimationController = GetComponent<GranjeroAnimationController>();
        _lanzaObjeto = GetComponent<LanzaObjeto>();
    }

    private void Update()
    {
        
    }
}
