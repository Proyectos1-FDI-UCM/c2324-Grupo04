using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StairComponent : MonoBehaviour
{
    #region references

    private Transform _myTransform;
    [SerializeField] private Transform _endTransform;
    private Transform _playerTransform;
    private BoxCollider2D _myCollider;

    #endregion

    #region variables 

    [SerializeField] private float _maxDistance = 1f;
    [SerializeField] private float _exitDistance = 10f;
    [SerializeField] private float _lerpFactor = 1f;

    #endregion

    #region parameters

    private bool _goingDown = false;
    private bool _goingUp = false;

    #endregion

    #region methods

    private void OnUseStaircase(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (context.action.name == "GoDown" && !_goingDown && Mathf.Abs((_myTransform.position - _playerTransform.position).magnitude) <= _maxDistance)
            {
                StartDescending();
            }
            else if (context.action.name == "GoUp" && !_goingUp && Mathf.Abs((_myTransform.position - _playerTransform.position).magnitude) <= _maxDistance)
            {
                StartAscending();
            }
        }
    }

    private void StartDescending()
    {
        _playerTransform.position = _myTransform.position;
        _goingDown = true;
        _myCollider.enabled = false;
    }

    private void StartAscending()
    {
        _goingUp = true;
        _myCollider.enabled = false;
    }

    #endregion



    // Start is called before the first frame update
    void Start()
    {

        _myTransform = transform;
        _playerTransform = GameManager.Instance.ReferenciaTransformGranjero();
        _myCollider = GetComponent<BoxCollider2D>();

        InputAction goDownAction = GetComponent<PlayerInput>().actions["GoDown"];
        InputAction goUpAction = GetComponent<PlayerInput>().actions["GoUp"];

        goDownAction.performed += OnUseStaircase;
        goUpAction.performed += OnUseStaircase;

        goDownAction.Enable();
        goUpAction.Enable();
    }


    // Update is called once per frame
    void Update()
   {
    if (_goingDown)
    {
        if (Mathf.Abs((_myTransform.position - (_myTransform.position + _endTransform.position)).magnitude) <= _maxDistance)
        {
            FinishMovement();
            Debug.Log("Has llegado al fin de las escaleras");
        }
        else
        {
            _playerTransform.position = Vector3.Lerp(_playerTransform.position, _endTransform.position, Time.deltaTime * _lerpFactor);
        }
    }
    else if (_goingUp)
    {
        if (Mathf.Abs((_myTransform.position - (_myTransform.position + _endTransform.position)).magnitude) <= _maxDistance)
        {
            FinishMovement();
            Debug.Log("Has llegado arriba de las escaleras");
        }
        else
        {
            _playerTransform.position = Vector3.Lerp(_playerTransform.position, _myTransform.position, Time.deltaTime * _lerpFactor);
        }
    }
  }
    private void FinishMovement()
    {
        if (_goingDown)
        {
            _goingDown = false;
        }
        else if (_goingUp)
        {
            _goingUp = false;
        }
        _myCollider.enabled = true;
    }
}
