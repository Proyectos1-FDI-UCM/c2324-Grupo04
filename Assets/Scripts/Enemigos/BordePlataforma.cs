using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordePlataforma : MonoBehaviour
{
    public GameObject enemy;
    public void ChangeDirection(Vector2 movement, int limit)
    {
        Debug.Log("Cambia Dirreccion");
        if (limit == 1)
        {
            enemy.GetComponent<EnemigoMov>().movementEnemy = Vector2.right;
        }
        else if (limit == 2)
        {
            enemy.GetComponent<EnemigoMov>().movementEnemy = Vector2.left;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
