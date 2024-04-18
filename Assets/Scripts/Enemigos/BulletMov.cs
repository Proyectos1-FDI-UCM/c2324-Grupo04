using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMov : MonoBehaviour
{
    public Vector2 movementBullet;
    private Transform _myTransform;
    [SerializeField] private int speed = 5;
    private bool _collision;

    private void OnTriggerStay2D(Collider2D collision)
    {
        _collision = true;
    }

    void Start()
    {
        _myTransform = transform;
        movementBullet = Vector2.left;
        _collision = false;
    }

    void Update()
    {
        transform.Translate(movementBullet * speed * Time.deltaTime);
        if (_collision ) { Destroy(gameObject); }
    }
}
