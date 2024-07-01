using UnityEngine;

public class AttackHitboxComponent : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _parentTransform;

    private int _damage;
    private float _speed;
    private Vector2 _direction;
    private float _maxOffset;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entra en el trigger");
        EnemyMovement enemyMovement = other.GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            Debug.Log("Colisionado con un enemigo");
            other.GetComponent<HealthComponent>().ChangeHealth(_damage);
        }
    }

    private void Update()
    {
        if ((_transform.position - _parentTransform).magnitude < _maxOffset)
        {
            _transform.position += _direction.x * Vector3.right * _speed * Time.deltaTime;
        }
    }

    public void SetUp(int damage, float speed, Vector2 dir, Vector3 parentPosition, float maxOffset)
    {
        _damage = damage;
        _speed = speed;
        _direction = dir;
        _parentTransform = parentPosition;
        _maxOffset = maxOffset;
    }
}
