using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CachorroMov : MonoBehaviour
{
    private SensorEnem _sensorEnem;
    private EnemyMovement _enemyMovement;
    public GameObject limit1;
    public GameObject limit2;
    private int limit;
    private int cambioDirec = 0;
    private bool borde;
    [SerializeField]
    private float tiempoHuida;
    private float _tiempoHuida;
    private bool huida;

    private void OnTriggerEnter2D(Collider2D collision)
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

    private void seguirOveja()
    {
        _sensorEnem.seguirPlayer(ref cambioDirec);

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
    
    private void huir()
    {
        _sensorEnem.seguirPlayer(ref cambioDirec);

        if (borde && cambioDirec != 0)
        {
            if (limit == 1 && cambioDirec == 1) { cambioDirec = 0; }
            else { borde = true; }
            if (limit == 2 && cambioDirec == -1) { cambioDirec = 0; }
            else { borde = true; }
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
                huir();
                huida = true;
                _tiempoHuida = 0f;
            }
            //else if (_sensorEnem.ovejaDetected)
            //{
            //    //seguirOveja();  
            //}
            else
            {
                if (limit == 1) { GetComponent<EnemyMovement>().movementEnemy = Vector2.right; }
                else { GetComponent<EnemyMovement>().movementEnemy = Vector2.left; }
                borde = false;
            }
        }
        else { huir(); }
        _tiempoHuida += Time.deltaTime;
        if (_tiempoHuida > tiempoHuida) { huida = false; }
    }
}
