using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorcaAttack : MonoBehaviour
{
    [SerializeField] private int _damage = 2;
    [SerializeField] private float _hitboxSpeed = 2;
    private Vector2 _dir;
    [SerializeField] private float _hitboxDuration = 0.4f;
    [SerializeField] private GameObject _hitboxPrefab;
    [SerializeField] private float _horizontalOffset = 0.4f;
    private Transform _myTransform;
    private GranjeroMovement _myGranjeroMovement;

    void OnAction1()
    {
        GameObject hitbox = Instantiate(_hitboxPrefab, _myTransform.position, _myTransform.rotation);
        if (_myGranjeroMovement.Movement().x >= 0)
        {
            _dir = Vector2.right;
        }
        else
        {
            _dir = Vector2.left;
        }
        hitbox.GetComponent<AttackHitboxComponent>().SetUp(_damage, _hitboxSpeed, _dir, _myTransform.position, _horizontalOffset);

        Destroy(hitbox, _hitboxDuration);
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
