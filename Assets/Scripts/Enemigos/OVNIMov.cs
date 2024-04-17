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
    private Transform _transform;
    private int limit;
    private int cambioDirec = 0;
    private bool borde;
    
    
    private bool attacking;
    private bool canAttack;
    [SerializeField] private float cooldown;
    [SerializeField] private float windup;
    private float _passedTime;
    private bool timePassing;


    private void OnTriggerStay2D(Collider2D collision)//Detecta si hay colision con los bordes e indica que borde es
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

    private void seguir(int cambioDirec)//Script para seguir al señuelo (y a la oveja y el granjero)
    {
        if (borde && cambioDirec != 0)//Si intenta salir del borde se anula el movimiemto
        {
            if (limit == 1 && cambioDirec == -1) { cambioDirec = 0; }
            if (limit == 2 && cambioDirec == 1) { cambioDirec = 0; }
        }

        if (cambioDirec == -1)
        {
            GetComponent<EnemyMovement>().movementEnemy = Vector2.left;
        }
        else if (cambioDirec == 1)
        {
            GetComponent<EnemyMovement>().movementEnemy = Vector2.right;
        }
        else if (cambioDirec == 0)
        {
            GetComponent<EnemyMovement>().movementEnemy = Vector2.zero;
        }
    }

    private void prepAttack()//Script para la preparacion del ataque
    {
        if (_passedTime > cooldown)//Si ha pasado el cooldown del ataque, puede prepararse para otro ataque
        {
            canAttack = true;
            _passedTime = 0;
        }

        if (canAttack)
        {
            timePassing = false;
            if (cambioDirec == 0)//Si el OVNI esta justo encima del objetivo, empieza a prepararse para atacar
            {
                timePassing = true;
                if (_passedTime > windup)//Si el OVNI lleva un tiempo preparandose empieza el estado de ataque
                {
                    attacking = true;
                    canAttack = false;
                }
            }
            else { _passedTime = 0; }
        }
        else { timePassing = true; }
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

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timePassing) { _passedTime += Time.deltaTime; }

        if (attacking)//El OVNI tiene un estado de ataque, en el cual se desactiva el movimiento
        {
            _OVNIAttack.Attacking(ref attacking);
        }


        else
        {
            if (borde)//Si choca contra un borde cambia de dirreccion
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

            //La prioridad del OVNI es seguir al señuelo, seguir a la oveja, y seguir al jugador
            if (_sensorEnem.señueloDetected)//Si detecta algo lo sigue
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
