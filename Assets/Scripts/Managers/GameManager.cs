using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public Vector3 SeñueloPosition()
    {
        return _señueloTransform.position;
    }


    private int _cuerda = 0;
    private int _monedas = 0;

    public int ObjetosTotales { get { return _cuerda; } } // ¿Qué hace este método?

    public bool cargandoOveja = false;


    #endregion

    #region references 
    [SerializeField] HorcaAttack _playersHorcaAttack;
    [SerializeField] HealthComponent _playerHealth;
    [SerializeField] GranjeroMovement _granjeroMovement;
    private Transform _playerTransform;
    private Create _playerCreate;
    [SerializeField] private Transform _ovejaTransform;
    private UIManager _UIManager;
    private Transform _señueloTransform;
    public int nseñuelo = 0;
    public bool señueloExist = false;
    #endregion 

    #region methods

    public GranjeroMovement ReferenciaGranjero()
    {
        return _granjeroMovement;
    }

    public Transform ReferenciaTransformGranjero()
    {
        return _playerTransform;
    }

    public Transform ReferenciaTransformOveja()
    {
        return _ovejaTransform;
    }

    private void Awake()
    {
        if (_instance == null) _instance = this; // Sólo queremos un GameManager, así que usamos el patrón singleton
        else Destroy(gameObject);
        _playerTransform = _granjeroMovement.gameObject.transform;
    }

    private void Start()
    {
        _playerCreate = _granjeroMovement.gameObject.GetComponent<Create>();
        _UIManager = GetComponent<UIManager>();
    }

    private void ActivaHorca()
    {
        Debug.Log("Horca activada");
        _playersHorcaAttack.enabled = true;
    }

    private void ActivaPala()
    {
        // A implementar todavía
    }

    public void ActivaMov()
    {
        // A implementar todavía
        _granjeroMovement.enabled = true;
    }

    public void DesactivaMov()
    {
        // A implementar todavía
        _granjeroMovement.enabled = false;
    }

    public void RecogidaObjeto(TipoObjeto objeto)
    {
        if (objeto == TipoObjeto.Moneda)
        {
            _monedas++;
        }
        else if (objeto == TipoObjeto.Cuerda)
        {
            _cuerda++;
        }
        else if (objeto == TipoObjeto.RecetaSeñuelo)
        {
            _UIManager.RecogidaRecetaSeñuelo();
            _playerCreate.ActivaSeñuelo();
        }
        else if (objeto == TipoObjeto.RecetaTrampolin)
        {
            _UIManager.RecogidaRecetaTrampolin();
            _playerCreate.ActivaTrampolin();
        }
        else if (objeto == TipoObjeto.Horca)
        {
            _UIManager.RecogidaHorca();
            _playersHorcaAttack.ActivaHorca();
        }
        else if (objeto == TipoObjeto.Vida)
        {
            _playerHealth.ChangeHealth(_healthIncrement);
        }
        else if (objeto == TipoObjeto.VidaOveja)
        {
            _playerHealth.ChangeMaxHealth(_maxHealthIncrement);
            _playerHealth.ChangeHealth(_maxHealthIncrement);
        }
    }

    public void CogeOveja()
    {
        _granjeroMovement.OvejaRecogida();
        cargandoOveja = true;
    }

    public void SueltaOveja()
    {
        _granjeroMovement.OvejaSoltada();
        cargandoOveja = false;
    }

    public void ChangeCantidadCuerda(int value)
    {
        _cuerda += value;
        Debug.Log("Ahora tienes: " + _cuerda + " unidad(es) de cuerda");
    }


    public int ObtenerCuerdas()
    {
        return _cuerda;
    }

    public int ObtenerMonedas()
    {
        return _monedas;
    }

    public void SeñueloCreado(Transform señueloTransform)
    {
        señueloExist = true;
        _señueloTransform = señueloTransform;
    }

    public void SeñueloDestruido()
    {
        señueloExist = false;
        nseñuelo--;
    }

    public void ReiniciaEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion

    #region enums

    public enum TipoObjeto
    {
        Moneda,
        Cuerda,
        RecetaSeñuelo,
        RecetaTrampolin,
        Horca,
        Vida,
        VidaOveja
    }
    #endregion
}
