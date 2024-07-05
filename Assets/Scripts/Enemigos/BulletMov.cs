using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMov : MonoBehaviour
{
    public Vector2 movementBullet;
    private Transform _myTransform;
    [SerializeField] private int speed = 5;
    private bool _collision;
    private float destroyDelay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.GetComponent<GranjeroMovement>() != null) || (collision.gameObject.GetComponent<MovimientoOveja>() != null))
        {
            _collision = true;
        }
        
    }


    void Start()
    {
        _myTransform = transform;
        movementBullet = Vector2.left;
        _collision = false;
        destroyDelay = 0;
    }

    void Update()
    {
        if (_collision) { destroyDelay += Time.deltaTime; }
        if (destroyDelay > 0.1) { Destroy(gameObject); }
    }

    void FixedUpdate()
    {
        transform.Translate(movementBullet * speed * Time.deltaTime);
    }
}
