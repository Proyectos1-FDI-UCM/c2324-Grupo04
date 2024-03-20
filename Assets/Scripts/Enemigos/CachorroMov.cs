using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CachorroMov : MonoBehaviour
{
    private SensorEnem _sensorEnem;
    private EnemyMovement _enemyMovement;
    public GameObject limit1;
    public GameObject limit2;
    [SerializeField]
    private int limit;
    [SerializeField]
    private int cambioDirec = 0;
    private bool borde;
    [SerializeField]
    private float tiempoHuida;
    private float _tiempoHuida;
    private bool huida;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BordePlataforma>() != null)
        {
            if (collision.gameObject == limit1)
            {
                limit = 1;
                limit1.GetComponent<BordePlataforma>().ChangeDirection(_enemyMovement.movementEnemy, limit);
            }
            if (collision.gameObject == limit2)
            {
                limit = 2;
                limit2.GetComponent<BordePlataforma>().ChangeDirection(_enemyMovement.movementEnemy, limit);
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

    private void huir(int cambioDirec)
    {
        if (borde && cambioDirec != 0)
        {
            if (limit == 1 && cambioDirec == 1) { cambioDirec = 0; }
            if (limit == 2 && cambioDirec == -1) { cambioDirec = 0; }
        }

        if (cambioDirec == -1)
        {
            GetComponent<EnemyMovement>().movementEnemy = Vector2.right;
        }
        else if (cambioDirec == 1)
        {
            GetComponent<EnemyMovement>().movementEnemy = Vector2.left;
        }
        else if (cambioDirec == 0)
        {
            GetComponent<EnemyMovement>().movementEnemy = Vector2.zero;
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
        if (!huida)
        {
            if (cambioDirec == 0) { cambioDirec = -1; }
            if (_sensorEnem.playerDetected)
            {
                _sensorEnem.seguirPlayer(ref cambioDirec);
                huir(cambioDirec);
                huida = true;
                _tiempoHuida = 0f;
                Debug.Log("empieza a escapar");
            }
            else if (_sensorEnem.señueloDetected)
            {
                _sensorEnem.seguirSeñuelo(ref cambioDirec);
                seguir(cambioDirec);
            }
            else if (_sensorEnem.ovejaDetected)
            {
                _sensorEnem.seguirOveja(ref cambioDirec);
                seguir(cambioDirec);
            }
            else
            {
                if (limit == 1) { GetComponent<EnemyMovement>().movementEnemy = Vector2.right; }
                else { GetComponent<EnemyMovement>().movementEnemy = Vector2.left; }
            }
        }
        else { _sensorEnem.seguirPlayer(ref cambioDirec); huir(cambioDirec); Debug.Log("escapando"); }
        _tiempoHuida += Time.deltaTime;
        if (_tiempoHuida > tiempoHuida) { huida = false; Debug.Log("termina de escapar"); }
        Debug.Log("Cachorro borde: " + borde);
        borde = false;
    }
}
