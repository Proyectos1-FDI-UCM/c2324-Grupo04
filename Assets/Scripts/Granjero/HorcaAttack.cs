using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorcaAttack : MonoBehaviour
{
    [SerializeField] private int _damage = - 2;
    [SerializeField] private float _hitboxSpeed = 2;
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
            Vector2 position = _myTransform.position.x * Vector2.up + _myTransform.position.y * Vector2.right + _dir * _horizontalOffset;
            Collider2D result = Physics2D.OverlapCircle(position, _hitboxRadius);
            if (result != null && result.gameObject.GetComponent<EnemyMovement>() != null)
            {
                result.gameObject.GetComponent<HealthComponent>().ChangeHealth(_damage);
            }
            if (result ==  null)
            {
                Debug.Log("No ha encontrado un collider");
            }
            if (result.gameObject.GetComponent<EnemyMovement>() != null)
            {
                Debug.Log("El collider no tiene EnemyMovement");
            }
            //Vector2 position = _myTransform.position.x * Vector2.up + _myTransform.position.y * Vector2.right + _dir * _horizontalOffset;
            //Collider2D[] results = new Collider2D[10];
            //int n = Physics2D.OverlapCircle(position, _hitboxRadius, ContactFilter2D.NoFilter, results);
            //if (results[0].gameObject.GetComponent<EnemyMovement>() != null)
            //{
            //    results[0].gameObject.GetComponent<HealthComponent>().ChangeHealth(_damage);
            //}
        }
    }

    public void ActivaHorca()
    {
        _puedeAtacar = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _myGranjeroMovement = GetComponent<GranjeroMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
