using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoOveja : MonoBehaviour // Componente perteneciente a la oveja
{
    #region references

    private Transform _myTransform;
    private Rigidbody2D _myRB;
    //private SpriteRenderer _mySR;
    //private GranjeroMovement _myGranjeroMovement;
    #endregion

    #region parameters

    [SerializeField]
    private float _walkSpeed = 1.8f;
    [SerializeField]
    private float _waitTime = 2f;
    //[SerializeField] private float _verticalOffset = 1f;
    #endregion

    #region variables
    private float _cont = 0f;
    private bool _grounded = true;
    private Vector2 _dir;
    #endregion




    public void SueltaOveja(float dir = 1)
    {
        // Llamar a la animación
        _dir = new Vector2(dir, 0);
        _grounded = true;
        _myTransform.localScale = new Vector3(dir, 1, 1);
    }

    public void CogeOveja()
    {
        // Llamar a la animación
        _cont = 0f;
        _grounded = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_grounded)
        {
            if (_cont >= _waitTime)
            {
                _myRB.velocity = _walkSpeed * _dir + _myRB.velocity.y * Vector2.up;
            }
            else
            {
                _cont += Time.deltaTime;
            }
        }
    }
}
