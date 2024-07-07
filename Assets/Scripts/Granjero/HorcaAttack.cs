using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorcaAttack : MonoBehaviour
{
    [SerializeField] private int _damage = - 2;

    [SerializeField] private LayerMask _Layer;

    [SerializeField] private GameObject _hitboxPrefab;
    [SerializeField] private float _horizontalOffset = 0.4f;
    [SerializeField] private float _hitboxRadius = 2f;
    private Transform _myTransform;
    private GranjeroMovement _myGranjeroMovement;
    private PlayerAnimationController _myAnimationController;
    private bool _puedeAtacar = false;

    private void OnAction1()
    {
        if (_puedeAtacar)
        {
            // Llamada a la animación de ataque
            _myAnimationController.Ataca();
            Vector2 _dir;

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
            }
        }
    }

    public void ActivatePitchfork()
    {
        _puedeAtacar = true;
    }

    void Start()
    {
        _myTransform = transform;
        _myGranjeroMovement = GetComponent<GranjeroMovement>();
        _myAnimationController = GetComponent<PlayerAnimationController>();
    }
}
