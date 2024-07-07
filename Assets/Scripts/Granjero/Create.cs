using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject Trampoline;

    [SerializeField]
    private GameObject Señuelo;
    private Transform _myTransform;
    private PlayerAnimationController _myAnimationController;
    private GranjeroMovement _playerMovement;
    private Player_Raycast _myRC;

    #endregion


    #region parameters
    [SerializeField]
    private float _horizontalOffset = 1;
    #endregion


    #region variables
    private bool _puedeTrampolin = false;
    private bool _puedeSeñuelo = false;
    #endregion



    #region input methods
    private void OnAction2()
    {
        if (_puedeTrampolin && GameManager.Instance.ObtenerCuerdas() > 0 && _myRC.ChoqueAbajo()) 
        {
            //Llamada a la animación
            _myAnimationController.SueltaObjeto();

            Vector2 spawnPos;
            if (_playerMovement.Movement().x < 0 && !_myRC.ChoqueIzq())
            {
                spawnPos = new Vector2(_myTransform.position.x - _horizontalOffset, _myTransform.position.y);
                GameObject trampolin = Instantiate(Trampoline, spawnPos, Quaternion.identity);
            }
            else if (_playerMovement.Movement().x >= 0 && !_myRC.ChoqueDer()) // Esta condición es necesaria para asegurarnos de no instanciar algo en una pared
            {
                spawnPos = new Vector2(_myTransform.position.x + _horizontalOffset, _myTransform.position.y);
                GameObject trampolin = Instantiate(Trampoline, spawnPos, Quaternion.identity);
            }
            GameManager.Instance.ChangeCantidadCuerda(-1);
            HudManager.instance.UpdateCuerda(1);
        }
    }

    private void OnAction3()
    {
        if (_puedeSeñuelo && GameManager.Instance.ObtenerCuerdas() > 0 && _myRC.ChoqueAbajo()) 
        {
            //Llamada a la animación
            _myAnimationController.SueltaObjeto();

            Vector2 spawnPos;
            if (_playerMovement.Movement().x < 0 && !_myRC.ChoqueIzq())
            {
                spawnPos = new Vector2(_myTransform.position.x - _horizontalOffset, _myTransform.position.y);
                GameManager.Instance.nseñuelo++;
                GameObject señuelo = Instantiate(Señuelo, spawnPos, Quaternion.identity);
            }
            else if (_playerMovement.Movement().x >= 0 && !_myRC.ChoqueDer())  // Esta condición es necesaria para asegurarnos de no instanciar algo en una pared
            {
                spawnPos = new Vector2(_myTransform.position.x + _horizontalOffset, _myTransform.position.y);
                GameManager.Instance.nseñuelo++;
                GameObject señuelo = Instantiate(Señuelo, spawnPos, Quaternion.identity);
            }
            GameManager.Instance.ChangeCantidadCuerda(-1);
            HudManager.instance.UpdateCuerda(1);
        }
    }
    #endregion
    #region methods
    public void ActivateTrampoline()
    {
        _puedeTrampolin = true;
    }

    public void ActivateDecoy()
    {
        _puedeSeñuelo = true;
    }
    #endregion
    #region Unity methods
    private void Start()
    {
        _myTransform = transform;
        _playerMovement = GetComponent<GranjeroMovement>();
        _myAnimationController = GetComponent<PlayerAnimationController>();
        _myRC = GetComponent<Player_Raycast>();
    }
    #endregion
}
