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
    [SerializeField] private float invulnerabilidad;
    private float _invulnerabilidadGranjero;
    private float _invulnerabilidadOveja;
    private float _invulnerabilidadSeñuelo;
    bool _recibeDaño = false;



    // Start is called before the first frame update
    void Start()
    {
        //_currentHp = _maxHp;
        _thisIsPlayer = GetComponent<GranjeroMovement>() != null;
        _thisIsSheep = GetComponent<OvejaInteraction>() != null;
        _thisIsSeñuelo = GetComponent<Señuelo>() != null;
        _thisIsEnemy = GetComponent<EnemyMovement>() != null;
        _invulnerabilidadGranjero = 0;
        _invulnerabilidadOveja = 0;
        _invulnerabilidadSeñuelo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _invulnerabilidadGranjero += Time.deltaTime; // No creo que sea necesario tener tres temporizadores independientes a la vez - R
        _invulnerabilidadOveja += Time.deltaTime;
        _invulnerabilidadSeñuelo += Time.deltaTime;
    }

    public void ChangeHealth(int increment)
    {
        _recibeDaño = false;
        if (_thisIsPlayer && _invulnerabilidadGranjero > invulnerabilidad) // Creo que nos podríamos ahorrar algunas de estas comprobaciones con lo que he comentado en el método Update() - R 
        {
            _recibeDaño = true;
            _invulnerabilidadGranjero = 0;
            //UIManager.Instance.ActualizaVidaGranjero();
            //print("Entro en el HC del granjero");
        }
        else if (_thisIsSheep && _invulnerabilidadOveja > invulnerabilidad)
        {
            _recibeDaño = true;
            _invulnerabilidadOveja = 0;
            //UIManager.Instance.ActualizaVidaOveja();
            //print("Entro en el HC de la oveja");
        }
        else if (_thisIsSeñuelo && _invulnerabilidadSeñuelo > invulnerabilidad)
        {
            _recibeDaño = true;
            _invulnerabilidadSeñuelo = 0;
        }
        else if (_thisIsEnemy)
        {
            _recibeDaño = true;
        }

        if (_recibeDaño) // Quizá sea mejor que el método ChangeHealth sea ciego a la invulnerabilidad, no sé - R
        {
            Debug.Log("Cambio de vida: " + increment);
            _currentHp += increment;
        }
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
        if (_currentHp > _maxHp)
        {
            _currentHp = _maxHp;
        }
    }

    private void Die()
    {
        Debug.Log("This is player: " + _thisIsPlayer);
        if (_thisIsPlayer || _thisIsSheep)
        {
            GameManager.Instance.ReiniciaEscena();
            Debug.Log("Fin de la partida");
        }
        else
        {
            if (_thisIsSeñuelo) { GameManager.Instance.SeñueloDestruido(); }
            Destroy(this.gameObject);
        }
    }

}
