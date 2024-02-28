using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region properties
    

    static private GameManager _instance;
    

    static public GameManager Instance // Todos podéis usar este método (escrito: GameManager.Instance) para acceder al GameManager y a cualquiera de sus métodos
    {
        get { return _instance; }
    }

    private int _cuerda;
    private int _monedas;

    public int ObjetosTotales { get { return _cuerda; } } // ¿Qué hace este método?

    #endregion

    #region references 
    [SerializeField] HorcaAttack _playersHorcaAttack;
    [SerializeField] HealthComponent _playerHealth;
    #endregion 

    #region methods

    private void Awake()
    {
        if (_instance == null) _instance = this; // Sólo queremos un GameManager, así que usamos el patrón singleton
        else Destroy(gameObject);
    }

    private void Start()
    {
        
    }

    private void ActivaHorca()
    {
        //_playersHorcaAttack.SetActive(true);
        _playersHorcaAttack.enabled = true;
    }

    public void RefistrarObjetos(int codigo)
    {
        if (codigo < 10)
        {
            if (codigo == 0)
            {
                _cuerda++;
            }
            else if (codigo == 1)
            {
                _monedas++;
            }
            else if (codigo == 2)
            {
                _playerHealth.ChangeHealth(2);
            }
            else if (codigo == 3)
            {
                _playerHealth.ChangeMaxHealth(2);
            }
        }
        else if (codigo < 20)
        {

        }
        else if (codigo == 30)
        {
            Debug.Log("Has recogido una oveja");
        }
    }

    #endregion
}





    

