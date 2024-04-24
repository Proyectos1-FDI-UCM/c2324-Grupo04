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

    #endregion

    #region methods

    private void OnGoDown()
    {
        if (!_goingDown && Mathf.Abs((_myTransform.position - _playerTransform.position).magnitude) <= _maxDistance)
        {
            _playerTransform.position = _myTransform.position;
            _goingDown = true; Debug.Log("_goingDown: " + _goingDown);
            _myCollider.enabled = false;
        }
        if ( _goingDown )
        {
            Debug.Log("Ya estás bajando");
        }
        if (Mathf.Abs((_myTransform.position - _playerTransform.position).magnitude) > _maxDistance)
        {
            Debug.Log("Estás muy lejos");
        }
    }

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _playerTransform = GameManager.Instance.ReferenciaTransformGranjero();
        _myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_goingDown)
        {
            if (Mathf.Abs((_myTransform.position - (_myTransform.position + _endTransform.position)).magnitude) <= _maxDistance)
            {
                _goingDown = false;
                Debug.Log("Has llegado al fin de las escaleras");
            }
            else
            {
                _playerTransform.position = Vector3.Lerp(_playerTransform.position, _endTransform.position, Time.deltaTime * _lerpFactor);
            }
        }
    }
}
