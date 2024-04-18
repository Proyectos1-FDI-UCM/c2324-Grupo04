using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoOveja : MonoBehaviour // Componente perteneciente a la oveja
{
    #region variables

    //[SerializeField]    private float _interactionDistance = 1.8f;
    //[SerializeField] private float _horizontalOffset = 2f;
    //[SerializeField] private float _verticalOffset = 1f;

    #endregion


    #region references

    private Transform _myTransform;
    //private Rigidbody2D _myRB;
    //private SpriteRenderer _mySR;
    //private GranjeroMovement _myGranjeroMovement;


    #endregion


    public void SueltaOveja()
    {
        // Llamar a la animación

        
    }

    public void CogeOveja()
    {
        // Llamar a la animación


    }

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
