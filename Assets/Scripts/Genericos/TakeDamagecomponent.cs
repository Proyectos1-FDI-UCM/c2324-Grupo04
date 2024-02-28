using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamagecomponent : MonoBehaviour
{

    HealthComponent _healthComponent;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _healthComponent = GetComponent<HealthComponent>();
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        if (_healthComponent != null)
        {
            _healthComponent.changeHealth(damage);
        }
    }
}
