using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{

    public int CurrentHealth() 
    {
        return _currentHp;
    }


    public int MaxHealth()
    {
        return _maxHp;
    }

    [SerializeField] private int _maxHp = 3;
    [SerializeField] public int _currentHp = 3;
    bool _thisIsPlayer = false;
    bool _thisIsSheep = false;
    bool _thisIsSeñuelo = false;
    bool _thisIsEnemy = false;
    [SerializeField] private float _invulnerabilidad = -1; // Tener un valor 0 o negativo es igual a no tener invulnerabilidad
    private float _crono = 0f;

    #region setup methods
    public void SetInvTime(float tiempo)
    {
        _crono = tiempo;
    }
    #endregion


    #region Unity methods
    void Start()
    {
        //_currentHp = _maxHp;
        _thisIsPlayer = GetComponent<GranjeroMovement>() != null;
        _thisIsSheep = GetComponent<MovimientoOveja>() != null;
        _thisIsSeñuelo = GetComponent<Señuelo>() != null;
        _thisIsEnemy = GetComponent<EnemyMovement>() != null;
    }

    
    void Update()
    {
        if (_crono < _invulnerabilidad)
        {
            _crono += Time.deltaTime;
        }
    }
    #endregion


    #region run methods
    public bool ChangeHealth(int increment) // Tal como está también hay invulnerabilidad a la hora de aumentar la vida, en fin
    {
        if(increment < 0) // Recibe daño
        {
            if(_crono >= _invulnerabilidad) // Sólo revibe daño si ha acabado su tiempo de invulnerabilidad
            {
                _currentHp += increment;
                if (_currentHp <= 0)
                {
                    SendMessage("Die");
                }
                else
                {
                    SendMessage("AnimacionDaño");
                }
            }
        }
        else // Aumenta su vida
        {
            _currentHp += increment;
            if (_currentHp > _maxHp)
            {
                _currentHp = _maxHp;
            }
        }
        
        
        return _currentHp <= 0; // Booleano informativo de si el dueño del HealthComponent ha muerto
    }

    public void ChangeMaxHealth(int increment)
    {
        _maxHp += increment;
        if (_currentHp > _maxHp)
        {
            _currentHp = _maxHp;
        }
    }
    #endregion

}
