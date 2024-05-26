using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMov : MonoBehaviour
{
    private SensorEnem _sensorEnem;
    private EnemyMovement _enemyMovement;
    public GameObject limit1;
    public GameObject limit2;
    public GameObject bulletPrefab;
    private Transform _transform;
    private int limit;
    private int cambioDirec = 0;
    private bool borde;


    private bool attacking;
    private bool canAttack;
    private bool attacked;
    [SerializeField] private float cooldown;
    [SerializeField] private float attackTime;
    private float _passedTime;
    private bool timePassing;
    public GameObject bulletSpawn1;
    public GameObject bulletSpawn2;


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

    private void atacar(int cambioDirec)//Script para atacar al señuelo (y a la oveja y el granjero)
    {
        if (!attacked)
        {
            if (cambioDirec == -1)
            {
                Instantiate(bulletPrefab, bulletSpawn1.transform.position, bulletSpawn1.transform.rotation);
            }
            else
            {
                Instantiate(bulletPrefab, bulletSpawn2.transform.position, bulletSpawn2.transform.rotation);
            }
            canAttack = false;
            attacked = true;
            timePassing = false;
            _passedTime = 0;
        }
        if (_passedTime > attackTime)//Se para un tiempo despues de disparar
        {
            attacking = false;
        }
        else { timePassing = true; }
    }

    private void prepAttack()//Script para la preparacion del ataque
    {
        if (_passedTime > cooldown)//Si ha pasado el cooldown del ataque, puede prepararse para otro ataque
        {
            canAttack = true;
            attacked = false;
            _passedTime = 0;
        }
        else { timePassing = true; }

        if ((_sensorEnem.señueloDetected == true || _sensorEnem.playerDetected == true || _sensorEnem.ovejaDetected == true) && canAttack)//Ataca solo si hay algo en rango y haya pasado el cooldown
        {
            attacking = true;
            _passedTime = 0;  
        }
    }

    void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _sensorEnem = GetComponent<SensorEnem>();
        _transform = GetComponent<Transform>();
        borde = false;
        attacking = false;
        canAttack = true;
        attacked = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timePassing) { _passedTime += Time.deltaTime; }

        if (attacking)//Al atacar se detiene para disparar
        {
            atacar(cambioDirec);
            _enemyMovement.movementEnemy = Vector2.zero;
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

            //La prioridad del alien es atacar al señuelo, atacar al jugador, y atacar a la oveja, el alien no sigue, solo dispara
            if (_sensorEnem.señueloDetected)//Si detecta algo le dispara
            {
                _sensorEnem.seguirSeñuelo(out cambioDirec);
                prepAttack();
            }
            else if (_sensorEnem.playerDetected)
            {
                _sensorEnem.seguirPlayer(out cambioDirec);
                prepAttack();
            }
            else if (_sensorEnem.ovejaDetected)
            {
                _sensorEnem.seguirOveja(out cambioDirec);
                prepAttack();
            }
            
            if (limit == 1)
            {
                _enemyMovement.movementEnemy = Vector2.right;
            }
            else
            {
                _enemyMovement.movementEnemy = Vector2.left;
            }

            borde = false;
        }
    }
}
