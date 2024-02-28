using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemigoMov : MonoBehaviour
{
    public Vector2 movementEnemy;
    private Transform _myTransform;
    private HealthComponent _healthComponent;
    public GameObject player;

    [SerializeField] private int speed = 3;
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.GetComponent<GranjeroMovement>() != null)
        {
            player.GetComponent<HealthComponent>().changeHealth(damage);
            Debug.Log("Collision Granjero");
        }
    }

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
