using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region variables

    [SerializeField] private int _healthIncrement = 2;
    [SerializeField] private int _maxHealthIncrement = 2;

    #endregion
    #region properties


    static private GameManager _instance;
    

    static public GameManager Instance // Todos podéis usar este método (escrito: GameManager.Instance) para acceder al GameManager y a cualquiera de sus métodos
    {
        get { return _instance; }
    }

    public Vector3 PlayerPosition()
    {
        return _playerTransform.position;
    }

    public Vector3 OvejaPosition()
    {
        return _ovejaTransform.position;
    }



    private int _cuerda = 0;
    private int _monedas = 0;

    public int ObjetosTotales { get { return _cuerda; } } // ¿Qué hace este método?

    public bool cargandoOveja = false;


    #endregion

    #region references 
    [SerializeField] HorcaAttack _playersHorcaAttack;
    //[SerializeField] HorcaAttack _playersHorcaAttack;
    [SerializeField] HealthComponent _playerHealth;
    [SerializeField] GranjeroMovement _granjeroMovement;
    private Transform _playerTransform;
    [SerializeField] private Transform _ovejaTransform;
    #endregion 

    #region methods

    public GranjeroMovement ReferenciaGranjero()
    {
        return _granjeroMovement;
    }

    private void Awake()
    {
        if (_instance == null) _instance = this; // Sólo queremos un GameManager, así que usamos el patrón singleton
        else Destroy(gameObject);
    }

    private void Start()
    {
        _playerTransform = _granjeroMovement.gameObject.transform;
    }

    private void ActivaHorca()
    {
        Debug.Log("Horca activada");
        //_playersHorcaAttack.SetActive(true);
        _playersHorcaAttack.enabled = true;
    }

    private void ActivaPala()
    {

    }

    public void RegistraObjetos(int codigo)
    {
        if (codigo < 10)
        {
            if (codigo == 0)
            {
                _cuerda++; Debug.Log("Tienes " + _cuerda + " unidades de cuerda");
            }
            else if (codigo == 1)
            {
                _monedas++; Debug.Log("Tienes " + _monedas + " monedas");
            }
            else if (codigo == 2)
            {
                _playerHealth.ChangeHealth(_healthIncrement);
            }
            else if (codigo == 3)
            {
                _playerHealth.ChangeMaxHealth(_maxHealthIncrement);
            }
        }
        else if (codigo < 20)
        {
            if (codigo == 10)
            {
                ActivaHorca();
            }
            else if (codigo == 11)
            {
                ActivaPala();
            }
        }
        else if (codigo == 30)
        {
            Debug.Log("Has recogido la oveja");
            _granjeroMovement.OvejaRecogida();
        }
    }

    public void RegistraOveja()
    {
        _playerTransform.position = _ovejaTransform.position;
        _granjeroMovement.OvejaRecogida();
        cargandoOveja = true;
    }


    public int ObtenerCuerdas()
    {
        return _cuerda;
    }
    #endregion
}





    

