using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class ZorroMov : MonoBehaviour
{
    private SensorEnem _sensorEnem;
    private EnemyMovement _enemyMovement;
    public GameObject limit1;
    public GameObject limit2;
    private SpriteRenderer _spriteRenderer;
    private int limit;
    private int cambioDirec;
    private bool borde;

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

    private void seguir(int cambioDirec)//Script para seguir al señuelo (y a la oveja y el graanjero)
    {
        if (borde && cambioDirec != 0)//Si intenta salir del borde se anula el movimiemto
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
    void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _sensorEnem = GetComponent<SensorEnem>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
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

        //La prioridad del zorro es seguir al señuelo, seguir al jugador, y seguir a la oveja
        if (_sensorEnem.señueloDetected)//Si detecta algo lo sigue
        {
            _sensorEnem.seguirSeñuelo(out cambioDirec);
            seguir(cambioDirec);
        }
        else if (_sensorEnem.playerDetected)
        {
            _sensorEnem.seguirPlayer(out cambioDirec);
            seguir(cambioDirec);
        }
        else if (_sensorEnem.ovejaDetected)
        {
            _sensorEnem.seguirOveja(out cambioDirec);
            seguir(cambioDirec);
        }
        
        else
        {
            if (limit == 1) { _enemyMovement.movementEnemy = Vector2.right; }
            else { _enemyMovement.movementEnemy = Vector2.left; }
        }

        flip();
        borde = false;
    }

    private void flip() //Este método hace que la animación se de la vuelta
    {
        if (_enemyMovement.movementEnemy.x == 1)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_enemyMovement.movementEnemy.x == -1)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
