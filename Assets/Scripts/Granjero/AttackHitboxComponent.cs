using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitboxComponent : MonoBehaviour
{
    #region references 

    private Transform _myTransform;
    private Vector3 _parentTransform;

    #endregion

    #region parameters
    //[SerializeField] float _duration; // En principio es el HorcaAttack el que destruye este objeto
    int _damage; // HA DE SER UN NÚMERO NEGATIVO
    float _speed;
    Vector2 _direction;
    float _maxOffset;
    #endregion

    #region variables
    //float _timePassed = 0f;
    #endregion


    private void Awake()
    {
        _myTransform = transform;
    }

    public void SetUp(int damage, float speed, Vector2 dir, Vector3 parentPosition, float maxOffset)
    {
        _damage = damage;
        _speed = speed;
        _direction = dir;
        _parentTransform = parentPosition;
        _maxOffset = maxOffset;
    }


    public void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemyMovement = other.GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            other.GetComponent<HealthComponent>().ChangeHealth(_damage);
        }
    }

    void Update()
    {
        if ((_myTransform.position - _parentTransform).magnitude < _maxOffset)
        {
            _myTransform.position += _direction.x * Vector3.right * _speed * Time.deltaTime;
        }
    }
}
