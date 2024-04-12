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


    private Vector2 spawnPos; // Esto sobra aquí

    //private InventoryManager _inventoryManager; // No se usa ya
    #region parameters
    //[SerializeField]
    //private float _tacoste = 1; // Nunca se usa así que lo comento
    //[SerializeField]
    //private float _secoste = 0;  // Nunca se usa así que lo comento
    [SerializeField]
    private float _horizontalOffset = 1;
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

            GameObject trampolin = Instantiate(Trampoline, spawnPos, Quaternion.identity);
            //LanzaObjeto();
            GameManager.Instance.ChangeCantidadCuerda(-1);
            HudManager.instance.UpdateCuerda(1);
        }
    }

    private void OnAction3()
    {
        if (_puedeSeñuelo && GameManager.Instance.ObtenerCuerdas() > 0 && _playerMovement.choqueAbajo) 
        {
            //Llamada a la animación
            _myAnimationController.SueltaObjeto();

            GameManager.Instance.nseñuelo++;
            GameObject señuelo = Instantiate(Señuelo, spawnPos, Quaternion.identity);
            Debug.Log("Señuelo");
            GameManager.Instance.ChangeCantidadCuerda(-1);
            HudManager.instance.UpdateCuerda(1);
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
        if (_playerMovement.Movement().x < 0 && !_playerMovement.choqueIzq)
        {   
            spawnPos = new Vector2(_myTransform.position.x - _horizontalOffset, _myTransform.position.y);
        }
        else
        {
            spawnPos = new Vector2(_myTransform.position.x + _horizontalOffset, _myTransform.position.y);
        }

    }
}
