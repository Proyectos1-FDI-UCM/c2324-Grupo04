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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BordePlataforma>() != null)
        {
            Debug.Log("Collision Borde");
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
            if (limit == 1 && cambioDirec == -1) { cambioDirec = 0; Debug.Log("AA" + cambioDirec); }
            if (limit == 2 && cambioDirec == 1) { cambioDirec = 0; Debug.Log("BB" + cambioDirec); }
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
    void Update()
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
            _sensorEnem.seguirSeñuelo(ref cambioDirec);
            seguir(cambioDirec);
        }

        else
        {
            if (limit == 1) { GetComponent<EnemyMovement>().movementEnemy = Vector2.right; }
            else { GetComponent<EnemyMovement>().movementEnemy = Vector2.left; }
        }

        borde = false;
    }
}
