using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyMovement : MonoBehaviour
{
    public Vector2 movementEnemy;
    private Transform _myTransform;
    [SerializeField] private int speed = 3;
    void Start()
    {
        _myTransform = transform;
        movementEnemy = Vector2.left;
    }

    void Update()
    {
        transform.Translate(movementEnemy * speed * Time.deltaTime);
    }
}
