using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{

    public int CurrentHealth { get { return _currentHp; } }

    [SerializeField] int _startingHp = 3;
    [SerializeField] int _currentHp;
    [SerializeField] bool _thisIsPlayer = false;

    private GameManager _gameManager;


    // Start is called before the first frame update
    void Start()
    {
        _currentHp = _startingHp;
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    public void changeCurrentHealth(int damage)
    {
        Debug.Log("Cambia Vida");
        _currentHp -= damage;
        if(_currentHp > _startingHp) _currentHp = _startingHp;

        if (_currentHp <= 0) Die();
        Debug.Log(_currentHp);
    }
    private void Die()
    {
        if (_thisIsPlayer)
        {
           // _gameManager.PlayerIsDead();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
