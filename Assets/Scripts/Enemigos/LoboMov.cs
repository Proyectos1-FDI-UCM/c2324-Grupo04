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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BordePlataforma>() != null)
        {
            Debug.Log("Collision Borde");
            if (collision.gameObject == limit1)
            {
                limit = 1;
                limit1.GetComponent<BordePlataforma>().ChangeDirection(_enemyMovement.movementEnemy, limit);
                Debug.Log("Interacting with Child 1");
            }
            if (collision.gameObject == limit2)
            {
                limit = 2;
                limit2.GetComponent<BordePlataforma>().ChangeDirection(_enemyMovement.movementEnemy, limit);
                Debug.Log("Interacting with Child 2");
            }
            Debug.Log(_enemyMovement.movementEnemy);
        }
    }

    private void seguir(int cambioDirec)
    {
        if (borde && cambioDirec != 0)
        {
            if (limit == 1 && cambioDirec == -1) { cambioDirec = 0; }
            else { borde = true; }
            if (limit == 2 && cambioDirec == 1) { cambioDirec = 0; }
            else { borde = true; }
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
            borde = false;
        }
    }
}
