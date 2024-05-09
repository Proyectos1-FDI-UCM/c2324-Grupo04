using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;

public class UIManager : MonoBehaviour
{
    #region references

    [SerializeField]
    GameObject _menuDePausa;
    [SerializeField]
    GameObject _instruccionesTrampolin;
    [SerializeField]
    GameObject _instruccionesSeñuelo;
    [SerializeField]
    GameObject _instruccionesHorca;
    [SerializeField]
    GameObject _instruccionesMovimiento;
    [SerializeField]
    Healthbar _corazonesHUD;
    [SerializeField]
    Healthbar _corazonesHUDOveja;
    [SerializeField] GameObject victory;
    [SerializeField] GameObject pauseReset;
    [SerializeField] private GameObject _menuAjustes;
    [SerializeField] private GameObject _menuExitSettings;
    [SerializeField] private GameObject _menuOpciones;
    [SerializeField] private GameObject _menuSonido, _menuControles;
    public GameObject enterSettings, exitSettings, enterSonido, exitSonido, enterControles, exitControles;

    [SerializeField] private Animator _animator;

    #endregion

    #region variables

    [SerializeField] private float _duracionInstrucciones = 1f;


    #endregion

    #region properties

    static private UIManager _instance;


    static public UIManager Instance // Todos podeis usar este metodo (escrito: UIManager.Instance) para acceder al UIManager y a cualquiera de sus metodos
    {
        get { return _instance; }
    }


    #endregion

    #region methods

    public void ActualizaVidaGranjero()
    {
        Debug.Log("ActualizaVidaGranjero()");
        _corazonesHUD.ActualizaEstados();
    }

    public void ActualizaVidaOveja()
    {
        Debug.Log("ActualizaVidaOveja()");
        _corazonesHUDOveja.ActualizaEstados();
    }


    #endregion

    private bool _paused = false;
    // Start is called before the first frame update
    void Awake()
    {
        _menuControles.SetActive(false);
        _menuAjustes.SetActive(false);
        _menuOpciones.SetActive(false);
        _menuSonido.SetActive(false);
        _menuDePausa.SetActive(false);
        _instruccionesSeñuelo.SetActive(false);
        _instruccionesTrampolin.SetActive(false);
        _instruccionesHorca.SetActive(false);
        _instruccionesMovimiento.SetActive(true);
        //Destroy(_instruccionesMovimiento, _duracionInstrucciones);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region interfaz de usuario

    #endregion
    #region instrucciones
    public void RecogidaRecetaSeñuelo()
    {
        _instruccionesSeñuelo.SetActive(true); Debug.Log("RecogidaRecetaSeñuelo");
        //Destroy(_instruccionesSeñuelo, _duracionInstrucciones);
    }

    public void RecogidaRecetaTrampolin()
    {
        _instruccionesTrampolin.SetActive(true);
        //Destroy(_instruccionesTrampolin, _duracionInstrucciones);
    }

    public void RecogidaHorca()
    {
        _instruccionesHorca.SetActive(true);
        //Destroy(_instruccionesHorca, _duracionInstrucciones);
    }
    #endregion
    #region menos

    public void ClickSettings()
    {
        Time.timeScale = 1f;
        Invoke("AuxClickSettings", 0.15f);
    }

    private void AuxClickSettings()
    {
        EventSystem.current.SetSelectedGameObject(null);
        _menuAjustes.SetActive(true);
        _menuOpciones.SetActive(true);
        _menuSonido.SetActive(false);
        _menuControles.SetActive(false);
        _animator.SetBool("isOpen", true);
        Invoke("SelectExitSettings", 0.85F);
    }

    private void SelectExitSettings()
    {
        EventSystem.current.SetSelectedGameObject(enterSettings);
        Time.timeScale = 0f;
    }

    public void ExitSettings()
    {
        _menuAjustes.SetActive(false);
        _menuExitSettings.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(exitSettings);
    }

    public void ClickSonido()
    {
        _menuOpciones.SetActive(false);
        _menuSonido.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(enterSonido);
    }

    public void SalirSonido()
    {
        _menuOpciones.SetActive(true);
        _menuSonido.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(exitSonido);
    }

    public void ClickControles()
    {
        _menuOpciones.SetActive(false);
        _menuControles.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(enterControles);
    }

    public void SalirControles()
    {
        _menuOpciones.SetActive(true);
        _menuControles.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(exitControles);
    }

    public void OnPause()
    {
        if (!victory.active)
        {
            if (_paused)
            {
                Debug.Log("Salida de pausa");
                _menuAjustes.SetActive(false);
                _menuDePausa.SetActive(false);
                Time.timeScale = 1.0f;
                _paused = false;
            }
            else
            {
                Debug.Log("PAUSA");
                _menuDePausa.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(pauseReset);
                Time.timeScale = 0.0f;
                _paused = true;
            }
        }
        
    }
    #endregion
}
