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


    private InventoryManager _inventoryManager;

    [SerializeField]
    private float _tacoste = 1;
    [SerializeField]
    private float _secoste = 0;

    private bool _puedeTrampolin = false;
    private bool _puedeSeñuelo = false;

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

        if (_puedeTrampolin && GameManager.Instance.ObtenerCuerdas() > 0 && _playerMovement.choqueAbajo) //_puedeTrampolin &&
        {
            GameObject trampolin = Instantiate(Trampoline, _myTransform.position, Quaternion.identity);
            GameManager.Instance.ChangeCantidadCuerda(-1);
        }
    }

    private void OnAction3()
    {
        //if (_inventoryManager.nCuerda > 0 && _playerMovement.choqueAbajo) //_puedeSeñuelo && 
        //{
        //    GameObject señuelo = Instantiate(Señuelo, _myTransform.position, Quaternion.identity);
        //    print(señuelo);
        //    Debug.Log("Señuelo");
        //    _inventoryManager.ChangeCantidadCuerda(-1);
        //}
        if (_puedeSeñuelo && GameManager.Instance.ObtenerCuerdas() > 0 && _playerMovement.choqueAbajo) //_puedeSeñuelo && 
        {
            GameObject señuelo = Instantiate(Señuelo, _myTransform.position, Quaternion.identity);
            Debug.Log("Señuelo");
            GameManager.Instance.ChangeCantidadCuerda(-1);
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
        //_inventoryManager = FindObjectOfType<InventoryManager>();

        _myTransform = transform;
        _playerMovement = GetComponent<GranjeroMovement>();
    }

}
