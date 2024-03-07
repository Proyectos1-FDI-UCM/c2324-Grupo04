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

    #endregion

    #region variables 

    private float _maxDistance = 0.2f;
    [SerializeField] private float _lerpFactor = 1f;

    #endregion

    #region parameters

    private bool _goingDown = false;

    #endregion

    //#region methods

    //private void OnGoDown()
    //{
    //    if (!_goingDown &&  Mathf.Abs((_myTransform.position - _playerTransform.position).magnitude) <= _maxDistance)
    //    {
    //        _playerTransform.position = _myTransform.position;
    //        _goingDown = true; Debug.Log("_goingDown: " + _goingDown);
    //    }
    //}

    //#endregion



    //// Start is called before the first frame update
    //void Start()
    //{
    //    _myTransform = transform;
    //    _playerTransform = GameManager.Instance.ReferenciaTransformGranjero();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (_goingDown)
    //    {
    //        _playerTransform.position = Vector3.Lerp(_playerTransform.position, _endTransform.position, _lerpFactor);
    //    }
    //}
}
