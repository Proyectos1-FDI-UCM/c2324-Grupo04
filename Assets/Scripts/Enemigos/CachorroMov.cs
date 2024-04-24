using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CachorroMov : MonoBehaviour
{
    private SensorEnem _sensorEnem;
    private EnemyMovement _enemyMovement;
    public GameObject limit1;
    public GameObject limit2;
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private int limit;
    [SerializeField]
    private int cambioDirec = 0;
    private bool borde;
    [SerializeField]
    private float tiempoHuida;
    private float _tiempoHuida;
    private bool huida;

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
    private void flip() //Este método hace que la animación se de la vuelta
    {
        if (_enemyMovement.movementEnemy.x == -1)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_enemyMovement.movementEnemy.x == 1)
        {
            _spriteRenderer.flipX = false;
        };
    }

    private void seguir(int cambioDirec)//Script para seguir al señuelo (y a la oveja)
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

    private void huir(int cambioDirec)//igual que el script de seguir, pero con las dirrecciones contrarias para huir
    {
        if (borde && cambioDirec != 0)
        {
            if (limit == 1 && cambioDirec == 1) { cambioDirec = 0; }
            if (limit == 2 && cambioDirec == -1) { cambioDirec = 0; }
        }

        if (cambioDirec == -1)
        {
            _enemyMovement.movementEnemy = Vector2.right;
           
        }
        else if (cambioDirec == 1)
        {
            _enemyMovement.movementEnemy = Vector2.left;
            
        }
        else if (cambioDirec == 0)
        {
            _enemyMovement.movementEnemy = Vector2.zero;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _sensorEnem = GetComponent<SensorEnem>();
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

        if (!huida)//El cachorro tiene un estado de huida, si no esta huyendo se mueve como el resto de enemigos
        {
            //La prioridad del cachorro es huir del jugador, seguir al señuelo, y seguir a la oveja
            if (_sensorEnem.playerDetected)//Si detecta al jugador entra en estado de huida
            {
                _sensorEnem.seguirPlayer(out cambioDirec);
                huir(cambioDirec);
                huida = true;
                _tiempoHuida = 0f;
            }
            else if (_sensorEnem.señueloDetected)//Si detecta el señuelo o a la oveja los sigue
            {
                _sensorEnem.seguirSeñuelo(out cambioDirec);
                seguir(cambioDirec);
            }
            else if (_sensorEnem.ovejaDetected)
            {
                _sensorEnem.seguirOveja(out cambioDirec);
                seguir(cambioDirec);
            }
            else//Si no detecta nada sigue moviendose dependiendo del ultimo borde con el que interractuo
            {
                if (limit == 1) { _enemyMovement.movementEnemy = Vector2.right; }
                else { _enemyMovement.movementEnemy = Vector2.left; }
            }
        }
        else { _sensorEnem.seguirPlayer(out cambioDirec); huir(cambioDirec); }//Estado de huida, dura una cantidad de tiempo despues de detectar al jugador
        _tiempoHuida += Time.deltaTime;
        if (_tiempoHuida > tiempoHuida) { huida = false; }

        flip();
        borde = false;
    }
}
