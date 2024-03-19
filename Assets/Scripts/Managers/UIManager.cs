using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region references

    [SerializeField]
    GameObject _menuDePausa;
    [SerializeField]
    GameObject _instruccionesTrampolin;
    [SerializeField]
    GameObject _instruccionesSe�uelo;
    [SerializeField]
    GameObject _instruccionesHorca;
    [SerializeField]
    GameObject _instruccionesMovimiento;
    [SerializeField]
    GameObject[] _corazones;

    #endregion

    #region variables

    [SerializeField] private float _duracionInstrucciones = 1f;


    #endregion

    private bool _paused = false;
    // Start is called before the first frame update
    void Start()
    {
        _menuDePausa.SetActive(false);
        _instruccionesSe�uelo.SetActive(true);
        _instruccionesTrampolin.SetActive(true);
        _instruccionesHorca.SetActive(false);
        _instruccionesMovimiento.SetActive(true);
        Destroy(_instruccionesMovimiento, _duracionInstrucciones);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region interfaz de usuario

    #endregion
    #region instrucciones
    public void RecogidaRecetaSe�uelo()
    {
        _instruccionesSe�uelo.SetActive(true); Debug.Log("RecogidaRecetaSe�uelo");
        Destroy(_instruccionesSe�uelo, _duracionInstrucciones);
    }

    public void RecogidaRecetaTrampolin()
    {
        _instruccionesTrampolin.SetActive(true);
        Destroy(_instruccionesTrampolin, _duracionInstrucciones);
    }

    public void RecogidaHorca()
    {
        _instruccionesHorca.SetActive(true);
        Destroy(_instruccionesHorca, _duracionInstrucciones);
    }
    #endregion
    #region men�s
    private void OnPause()
    {
        
        if (_paused)
        {
            Debug.Log("Salida de pausa");
            _menuDePausa.SetActive(false);
            Time.timeScale = 1.0f;
            _paused = false;
        }
        else
        {
            Debug.Log("PAUSA");
            _menuDePausa.SetActive(true);
            Time.timeScale = 0.0f;
            _paused = true;
        }
    }
    #endregion
}
