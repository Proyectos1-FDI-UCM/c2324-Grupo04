using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Create : MonoBehaviour
{
    [SerializeField]
    private GameObject Trampoline;

    [SerializeField]
    private GameObject Se�uelo;
    private Transform _myTransform;

    private Vector2 spawnPos;

    private InventoryManager _inventoryManager;

    [SerializeField]
    private float _tacoste = 1;
    [SerializeField]
    private float _secoste = 0;

    private bool _puedeTrampolin = false;
    private bool _puedeSe�uelo = false;

    private GranjeroMovement _playerMovement;

    private void OnAction2()
    {
        //Debug.Log("instanciaTrampolin");
        // if (GameManager.Instance.ObtenerCuerdas() >= _tacoste && _playerMovement.choqueAbajo)

        //if ( _inventoryManager.nCuerda > 0 && _playerMovement.choqueAbajo) //_puedeTrampolin &&
        //{
        //    GameObject trampolin = Instantiate(Trampoline, _myTransform.position , Quaternion.identity);
        //    print(trampolin);
        //    Debug.Log("Trampolin");
        //    _inventoryManager.ChangeCantidadCuerda(-1);
        //}
        
        /*if (_playerMovement.movement.x < 0 && !_playerMovement.choqueIzq)
            {
                spawnPos = new Vector2(_myTransform.position.x + 1, _myTransform.position.y);
        }*/
        if (_puedeTrampolin && GameManager.Instance.ObtenerCuerdas() > 0 && _playerMovement.choqueAbajo) //_puedeTrampolin &&
        {
            GameObject trampolin = Instantiate(Trampoline, spawnPos, Quaternion.identity);
            GameManager.Instance.ChangeCantidadCuerda(-1);
        }
    }

    private void OnAction3()
    {
        //if (_inventoryManager.nCuerda > 0 && _playerMovement.choqueAbajo) //_puedeSe�uelo && 
        //{
        //    GameObject se�uelo = Instantiate(Se�uelo, _myTransform.position, Quaternion.identity);
        //    print(se�uelo);
        //    Debug.Log("Se�uelo");
        //    _inventoryManager.ChangeCantidadCuerda(-1);
        //}
        if (_puedeSe�uelo && GameManager.Instance.ObtenerCuerdas() > 0 && _playerMovement.choqueAbajo) //_puedeSe�uelo && 
        {
            GameObject se�uelo = Instantiate(Se�uelo, _myTransform.position, Quaternion.identity);
            Debug.Log("Se�uelo");
            GameManager.Instance.ChangeCantidadCuerda(-1);
        }
    }

    public void ActivaTrampolin()
    {
        _puedeTrampolin = true;
    }

    public void ActivaSe�uelo()
    {
        _puedeSe�uelo = true;
    }

    private void Start()
    {
        //_inventoryManager = FindObjectOfType<InventoryManager>();

        _myTransform = transform;
        _playerMovement = GetComponent<GranjeroMovement>();
    }

    private void Update()
    {
        if (_playerMovement.movement.x < 0 && !_playerMovement.choqueIzq)
        {
            spawnPos = new Vector2(transform.position.x - 1, _myTransform.position.y);
        }
        if (_playerMovement.movement.x > 0 && !_playerMovement.choqueDer)
        {
            spawnPos = new Vector2(transform.position.x + 1, _myTransform.position.y);
        }
    }
}
