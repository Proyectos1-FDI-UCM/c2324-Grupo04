using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Create : MonoBehaviour
{
    [SerializeField]
    private GameObject Trampoline;

    [SerializeField]
    private GameObject Señuelo;
    private Transform _myTransform;

    private Vector2 spawnPos;

    private InventoryManager _inventoryManager;

    [SerializeField]
    private float _tacoste = 1;
    [SerializeField]
    private float _secoste = 0;
    [SerializeField]
    private float _horizontalOffset = 1;

    private bool _puedeTrampolin = false;
    private bool _puedeSeñuelo = false;

    private GranjeroMovement _playerMovement;

    private void OnAction2()
    {

        if (_puedeTrampolin && GameManager.Instance.ObtenerCuerdas() > 0 && _playerMovement.choqueAbajo) 
        {
            GameObject trampolin = Instantiate(Trampoline, spawnPos, Quaternion.identity);
            GameManager.Instance.ChangeCantidadCuerda(-1);
            HudManager.instance.UpdateCuerda(1);
        }
    }

    private void OnAction3()
    {

        if (_puedeSeñuelo && GameManager.Instance.ObtenerCuerdas() > 0 && _playerMovement.choqueAbajo) 
        {
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
