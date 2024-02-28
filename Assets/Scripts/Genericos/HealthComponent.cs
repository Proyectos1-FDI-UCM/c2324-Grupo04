using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{

    public int CurrentHealth { get { return _currentHp; } }

    [SerializeField] private int _maxHp = 3;
    [SerializeField] private int _currentHp = 3;
    bool _thisIsPlayer = false;



    // Start is called before the first frame update
    void Start()
    {
        //_currentHp = _maxHp;
        _thisIsPlayer = GetComponent<GranjeroMovement>() != null;
    }

    // Update is called once per frame
    public void changeHealth(int added)
    {
        Debug.Log("Cambio de vida: " +  added);
        Debug.Log(_currentHp);
        _currentHp += added;
        if (_currentHp > _maxHp)
        {
            _currentHp = _maxHp;
        }

        if (_currentHp <= 0)
        {
            Die();
        }

    }
    private void Die()
    {
        if (_thisIsPlayer)
        {
           // GameManager.Instance.PlayerIsDead();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
