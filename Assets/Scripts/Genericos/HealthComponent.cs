using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{

    public int CurrentHealth { get { return _currentHp; } }

    [SerializeField] private int _maxHp = 3;
    [SerializeField] public int _currentHp = 3;
    bool _thisIsPlayer = false;



    // Start is called before the first frame update
    void Start()
    {
        //_currentHp = _maxHp;
        _thisIsPlayer = GetComponent<GranjeroMovement>() != null;
    }

    // Update is called once per frame
    public void ChangeHealth(int increment)
    {
        Debug.Log("Cambio de vida: " +  increment);
        _currentHp += increment;
        if (_currentHp > _maxHp)
        {
            _currentHp = _maxHp;
        }

        if (_currentHp <= 0)
        {
            Die();
        }

    }

    public void ChangeMaxHealth(int increment)
    {
        _maxHp += increment;
    }
    private void Die()
    {
        if (_thisIsPlayer)
        {
            // GameManager.Instance.PlayerIsDead();
            Debug.Log("Fin de la partida");
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
