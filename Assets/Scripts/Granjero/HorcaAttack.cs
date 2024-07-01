using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorcaAttack : MonoBehaviour
{
    [SerializeField] private int _damage = -2;
    [SerializeField] private LayerMask _layer;

    private Vector2 _dir;
    [SerializeField] private float _horizontalOffset = 0.4f;
    [SerializeField] private float _hitboxRadius = 2f;
    private Transform _transform;
    private GranjeroMovement _granjeroMovement;
    private PlayerAnimationController _animationController;
    private bool _canAttack = false;

    private void OnAction1()
    {
        if (_canAttack)
        {
            _animationController.Ataca();

            if (_granjeroMovement.Movement().x >= 0)
            {
                _dir = Vector2.right;
            }
            else
            {
                _dir = Vector2.left;
            }

            Collider2D[] results;
            Vector2 position = _transform.position.y * Vector2.up + _transform.position.x * Vector2.right + _dir * _horizontalOffset;
            Collider2D result = Physics2D.OverlapCircle(position, _hitboxRadius, _layer);

            if (result != null && result.gameObject.GetComponent<EnemyMovement>() != null)
            {
                result.gameObject.GetComponent<HealthComponent>().ChangeHealth(_damage);
            }
        }
    }

    private void Start()
    {
        _transform = transform;
        _granjeroMovement = GetComponent<GranjeroMovement>();
        _animationController = GetComponent<PlayerAnimationController>();
        Agarro();
    }

    public void Agarro()
    {
        _canAttack = true;
    }

    public void Suelta()
    {
        _canAttack = false;
    }
}
