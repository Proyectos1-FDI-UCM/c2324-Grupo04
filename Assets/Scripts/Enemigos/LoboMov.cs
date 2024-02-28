using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboMov : MonoBehaviour
{
    private EnemyMovement _enemyMovement;
    public GameObject limit1;
    public GameObject limit2;
    private int limit;

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
    // Start is called before the first frame update
    void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
