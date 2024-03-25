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
    bool _thisIsSe�uelo = false;
    [SerializeField] private float invulnerabilidad;
    private float _invulnerabilidadGranjero;
    private float _invulnerabilidadOveja;
    private float _invulnerabilidadSe�uelo;
    bool _recibeDa�o = false;



    // Start is called before the first frame update
    void Start()
    {
        //_currentHp = _maxHp;
        _thisIsPlayer = GetComponent<GranjeroMovement>() != null;
        _thisIsSheep = GetComponent<OvejaInteraction>() != null;
        _thisIsSe�uelo = GetComponent<Se�uelo>() != null;
        _invulnerabilidadGranjero = 0;
        _invulnerabilidadOveja = 0;
        _invulnerabilidadSe�uelo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _invulnerabilidadGranjero += Time.deltaTime;
        _invulnerabilidadOveja += Time.deltaTime;
        _invulnerabilidadSe�uelo += Time.deltaTime;
    }

    public void ChangeHealth(int increment)
    {
        _recibeDa�o = false;
        if (_thisIsPlayer && _invulnerabilidadGranjero > invulnerabilidad)
        {
            _recibeDa�o = true;
            _invulnerabilidadGranjero = 0;
            //UIManager.Instance.ActualizaVidaGranjero();
        }
        else if (_thisIsSheep && _invulnerabilidadOveja > invulnerabilidad)
        {
            _recibeDa�o = true;
            _invulnerabilidadOveja = 0;
            //UIManager.Instance.ActualizaVidaOveja();
        }
        else if (_thisIsSe�uelo && _invulnerabilidadSe�uelo > invulnerabilidad)
        {
            _recibeDa�o = true;
            _invulnerabilidadSe�uelo = 0;
        }

        if (_recibeDa�o)
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
            if (_thisIsSe�uelo) { GameManager.Instance.Se�ueloDestruido(); }
            Destroy(this.gameObject);
        }
    }

}
