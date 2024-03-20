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



    // Start is called before the first frame update
    void Start()
    {
        //_currentHp = _maxHp;
        _thisIsPlayer = GetComponent<GranjeroMovement>() != null;
        _thisIsSheep = GetComponent<OvejaInteraction>() != null;
        _thisIsSeñuelo = GetComponent<Señuelo>() != null;
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

        if (_thisIsPlayer)
        {
            UIManager.Instance.ActualizaVidaGranjero();
        }
        else if (_thisIsPlayer)
        {
            UIManager.Instance.ActualizaVidaOveja();
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
