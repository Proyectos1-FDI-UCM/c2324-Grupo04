using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVNIMov : MonoBehaviour
{
    private SensorEnem _sensorEnem;
    private EnemyMovement _enemyMovement;
    private OVNIAttack _OVNIAttack;
    public GameObject limit1;
    public GameObject limit2;
    private int limit;
    private int cambioDirec = 0;
    private bool borde;

    private bool attacking;
    private bool canAttack;
    [SerializeField] private float cooldown;
    [SerializeField] private float windup;
    private float _passedTime;
    private bool timePassing;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BordePlataforma>() != null)
        {
            if (collision.gameObject == limit1)
            {
                limit = 1;
            }
            if (collision.gameObject == limit2)
            {
                limit = 2;
            }
            borde = true;
        }
    }

    private void seguir(int cambioDirec)
    {
        if (borde && cambioDirec != 0)
        {
            if (limit == 1 && cambioDirec == -1) { cambioDirec = 0; }
            if (limit == 2 && cambioDirec == 1) { cambioDirec = 0; }
        }

        if (cambioDirec == -1)
        {
            _enemyMovement.movementEnemy = Vector2.left;
        }
        else if (cambioDirec == 1)
        {
            _enemyMovement.movementEnemy = Vector2.right;
        }
        else if (cambioDirec == 0)
        {
            _enemyMovement.movementEnemy = Vector2.zero;
        }
    }

    private void prepAttack()
    {
        if (canAttack && cambioDirec == 0)
        {
            if (_passedTime > windup)
            {
                attacking = true;
                canAttack = false;
                timePassing = false;
                _passedTime = 0;
            }
            else
            {
                timePassing = true;
            }
        }
        else
        {
            if (_passedTime > cooldown)
            {
                canAttack = true;
                _passedTime = 0;
            }
            else
            {
                timePassing = true;
            }
        }
    }

    void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _sensorEnem = GetComponent<SensorEnem>();
        _OVNIAttack = GetComponent<OVNIAttack>();
        borde = false;
        attacking = false;
        canAttack = true;
    }

    void FixedUpdate()
    {
        if (timePassing)
        {
            _passedTime += Time.deltaTime;
        }

        if (attacking)
        {
            _OVNIAttack.Attacking(ref attacking);
        }
        else
        {
            if (borde)
            {
                if (limit == 1)
                {
                    limit1.GetComponent<BordePlataforma>().ChangeDirection(_enemyMovement.movementEnemy, limit);
                }
                else
                {
                    limit2.GetComponent<BordePlataforma>().ChangeDirection(_enemyMovement.movementEnemy, limit);
                }
            }

            if (_sensorEnem.señueloDetected)
            {
                _sensorEnem.seguirSeñuelo(out cambioDirec);
                prepAttack();
                seguir(cambioDirec);
            }
            else if (_sensorEnem.ovejaDetected)
            {
                _sensorEnem.seguirOveja(out cambioDirec);
                prepAttack();
                seguir(cambioDirec);
            }
            else if (_sensorEnem.playerDetected)
            {
                _sensorEnem.seguirPlayer(out cambioDirec);
                prepAttack();
                seguir(cambioDirec);
            }
            else
            {
                if (limit == 1)
                {
                    _enemyMovement.movementEnemy = Vector2.right;
                }
                else if (limit == 2)
                {
                    _enemyMovement.movementEnemy = Vector2.left;
                }
            }

            borde = false;
        }
    }
}
