using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] int _hitPoints;
    [SerializeField] int _maxHitPoints;

    public void AddLife(int addition)
    {
        _hitPoints += addition;
        if (_hitPoints > _maxHitPoints)
        {
            _hitPoints = _maxHitPoints;
        }
        else if (_hitPoints < 0)
        {
            // Llamada a posible animación de muerte
            Destroy(this.GameObject); // Habría que ver cómo actuar en el caso de que sea el jugador el que muere
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
