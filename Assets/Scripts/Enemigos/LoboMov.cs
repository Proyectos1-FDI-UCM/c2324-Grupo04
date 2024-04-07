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
    private bool _enemyR, _enemyL;
    private Transform _transform;
    [SerializeField] private int _cambioDirecIni;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BordePlataforma>() != null)
        {
            // Debug.Log("Collision Borde");
            if (collision.gameObject == limit1)
            {
                limit = 1;
                //  flip();
            }
            if (collision.gameObject == limit2)
            {
                limit = 2;
                //  flip();
            }
            borde = true;
        }
    }

    private void seguir(int cambioDirec)
    {
        if (borde && cambioDirec != 0)
        {
            if (limit == 1 && cambioDirec == -1)
            {
                cambioDirec = 0; //Debug.Log("AA" + cambioDirec); }
                if (limit == 2 && cambioDirec == 1)
                {
                    cambioDirec = 0; //Debug.Log("BB" + cambioDirec); }
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
        }
    }
    void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _sensorEnem = GetComponent<SensorEnem>();
        _cambioDirecIni = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (_cambioDirecIni >= 1) //Este if es para corregir la direccion al principio, para que no parezca que camina de espaldas
        {
            flip();
            _cambioDirecIni--;
        }

        if (borde)
        {

            if (limit == 1)
            {
                limit1.GetComponent<BordePlataforma>().ChangeDirection(_enemyMovement.movementEnemy, limit);
                // _enemyR = true;               
            }
            else
            {
                limit2.GetComponent<BordePlataforma>().ChangeDirection(_enemyMovement.movementEnemy, limit);
                //_enemyR = true;
            }
        }

        /* if (_enemyR && limit == 1) 
         { 
             flip();
             _enemyR = false;
         }
         else if (_enemyR && limit != 1) 
         { 
             flip();
             _enemyR = false;
         }
        */

        if (cambioDirec == 0) { cambioDirec = -1; }

        if (_sensorEnem.señueloDetected)
        {
            _sensorEnem.seguirSeñuelo(out cambioDirec);
            seguir(cambioDirec);
        }

        else
        {
            if (limit == 1)
            {
                GetComponent<EnemyMovement>().movementEnemy = Vector2.right;
                
                if (_enemyR )
                {
                    flip();
                    _enemyR = false;
                    print("R");
                    _enemyL = true;
                }
                               
            }
            else if (limit == 2)
            {
                _enemyR = true;
                if (_enemyL)
                {
                    flip();
                    _enemyL = false;
                    print("R");
                }
                
                GetComponent<EnemyMovement>().movementEnemy = Vector2.left;
                print("L");
            }
        }

        borde = false;
    }

    private void flip() //Este método hace que la animación se de la vuelta
    {
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        print("FLIP");
    }


}
    
