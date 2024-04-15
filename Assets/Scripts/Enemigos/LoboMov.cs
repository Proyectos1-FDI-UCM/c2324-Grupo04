using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboMov : MonoBehaviour
{
    private SensorEnem _sensorEnem;
    private EnemyMovement _enemyMovement;
    public GameObject limit1;
    public GameObject limit2;
    private int limit;
    private int cambioDirec = 0;
    private bool borde;
    private bool _enemyR;
    private Transform _transform;
    private bool _cambioDirecIni;

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

    private void seguir(int cambioDirec)//Script para seguir al señuelo
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
        _cambioDirecIni = true;
        _enemyR = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_cambioDirecIni) //Este if es para corregir la direccion al principio, para que no parezca que camina de espaldas
        {
            flip();
            _cambioDirecIni = false;
        }

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


        //El lobo solo sigue a los señuelos
        if (_sensorEnem.señueloDetected)//Si detecta un señuelo lo sigue
        {
            _sensorEnem.seguirSeñuelo(out cambioDirec);
            seguir(cambioDirec);
        }

        else
        {
            if (limit == 1)
            {
                _enemyMovement.movementEnemy = Vector2.right;
                
                if (_enemyR )
                {
                    flip();
                    _enemyR = false;                
                }
                               
            }

            else if (limit == 2)
            {  
                _enemyMovement.movementEnemy = Vector2.left;

                
                if (!_enemyR)
                {
                    flip();
                    _enemyR = true;
                }
 
            }
        }

        borde = false;
    }

    private void flip() //Este método hace que la animación se de la vuelta
    {
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        //print("FLIP");
    }


}
    
