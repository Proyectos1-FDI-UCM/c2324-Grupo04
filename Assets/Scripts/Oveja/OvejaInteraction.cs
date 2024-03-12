using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OvejaInteraction : MonoBehaviour
{
    #region variables

    [SerializeField]    private float _interactionDistance = 1.8f;
    [SerializeField] private float _horizontalOffset = 2f;

    #endregion


    #region references

    private Transform _myTransform;
    private Rigidbody2D _myRB;
    private SpriteRenderer _mySR;
    private GranjeroMovement _myGranjeroMovement;


    #endregion


    private void OnInteraction1() // Método que se activa al recoger la oveja con la e
    {
        //Debug.Log("OnInteraction1()");

        if (GameManager.Instance.cargandoOveja)
        {
            //Debug.Log("Has dejado a la oveja");
            DejaOveja();
        }
        else if ((GameManager.Instance.PlayerPosition() - _myTransform.position).magnitude <= _interactionDistance)
        {
            //Debug.Log("Has recogido a la oveja");
            // Llamar a la desactivación de su sprite
            _mySR.enabled = false;
            // Llamar a la desactivación del rigidbody
            _myRB.simulated = false;
            // Llamar a la animación de recogida de la oveja del granjero
            GameManager.Instance.CogeOveja();
        }
        else
        {
            Debug.Log("Estás demasiado lejos");
        }
    }

    public void DejaOveja()
    {
        // Llamar 

        if (_myGranjeroMovement.Movement().x >= 0)
        {
            _myTransform.position = GameManager.Instance.PlayerPosition() + _horizontalOffset * Vector3.right;
        }
        else
        {
            _myTransform.position = GameManager.Instance.PlayerPosition() + _horizontalOffset * Vector3.left;
        }
        _myRB.simulated = true;
        _mySR.enabled = true;
        GameManager.Instance.SueltaOveja();
    }


    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _myRB = GetComponent<Rigidbody2D>();
        _mySR = GetComponent<SpriteRenderer>();
        _myGranjeroMovement = GameManager.Instance.ReferenciaGranjero();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
