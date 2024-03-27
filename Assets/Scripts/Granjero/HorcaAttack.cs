using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorcaAttack : MonoBehaviour
{
    [SerializeField] private int _damage = - 2;
    [SerializeField] private float _hitboxSpeed = 2;

    [SerializeField] private LayerMask _Layer;

    private Vector2 _dir;
    [SerializeField] private float _hitboxDuration = 0.4f;
    [SerializeField] private GameObject _hitboxPrefab;
    [SerializeField] private float _horizontalOffset = 0.4f;
    [SerializeField] private float _hitboxRadius = 1f;
    private Transform _myTransform;
    private GranjeroMovement _myGranjeroMovement;
    private bool _puedeAtacar = false;

    void OnAction1()
    {
        if (_puedeAtacar)
        {
            if (_myGranjeroMovement.Movement().x >= 0)
            {
                _dir = Vector2.right;
            }
            else
            {
                _dir = Vector2.left;
            }

            Collider2D[] results;
            Vector2 position = _myTransform.position.y * Vector2.up + _myTransform.position.x * Vector2.right + _dir * _horizontalOffset;
            Collider2D result = Physics2D.OverlapCircle(position, _hitboxRadius, _Layer);

            if (result != null && result.gameObject.GetComponent<EnemyMovement>() != null)
            {
                result.gameObject.GetComponent<HealthComponent>().ChangeHealth(_damage);
                Debug.Log("Colisiona");
            }
            if (result ==  null)
            {
                Debug.Log("No ha encontrado un collider");
            }
            else if (result.gameObject.GetComponent<EnemyMovement>() == null)
            {
                Debug.Log("El collider no tiene EnemyMovement");    
            }

        }
    }

    public void ActivaHorca()
    {
        _puedeAtacar = true;
    }

    void Start()
    {
        _myTransform = transform;
        _myGranjeroMovement = GetComponent<GranjeroMovement>();
    }
}
