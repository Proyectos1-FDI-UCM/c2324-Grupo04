using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZorroMov : MonoBehaviour
{
    private SensorEnem _sensorEnem;
    private EnemyMovement _enemyMovement;
    public GameObject limit1;
    public GameObject limit2;
    private int limit;
    private int cambioDirec = 0;
    private bool borde;

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
    void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _sensorEnem = GetComponent<SensorEnem>();
    }

    // Update is called once per frame
    void FixedUpdate()
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

        if (cambioDirec == 0) { cambioDirec = -1; }
        
        if (_sensorEnem.señueloDetected)
        {
            _sensorEnem.seguirSeñuelo(out cambioDirec);
            seguir(cambioDirec);
        }
        else if (_sensorEnem.playerDetected)
        {
            _sensorEnem.seguirPlayer(out cambioDirec);
            seguir(cambioDirec);
            Debug.Log("Siguiendo player");
        }
        else if (_sensorEnem.ovejaDetected)
        {
            _sensorEnem.seguirOveja(out cambioDirec);
            seguir(cambioDirec);
            Debug.Log("Siguiendo oveja");
        }
        
        else
        {
            if (limit == 1) { GetComponent<EnemyMovement>().movementEnemy = Vector2.right; }
            else { GetComponent<EnemyMovement>().movementEnemy = Vector2.left; }
        }

        borde = false;
    }
}
