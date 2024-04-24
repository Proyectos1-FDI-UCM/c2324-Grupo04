using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueMovible : MonoBehaviour
{
    #region references
    private Transform _myTransform;
    #endregion


    [SerializeField] private float _speed = 2;



    private void Start()
    {
        _myTransform = transform;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GranjeroMovement granjero = collision.gameObject.GetComponent<GranjeroMovement>();
        if (granjero != null)
        {
            Debug.Log("granjero.Movement().x: " + granjero.Movement().x);
            _myTransform.position += granjero.Movement().x * Vector3.right * _speed * Time.deltaTime;
        }
    }
}
