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

    private int objetosTotales;

    public int ObjetosTotales { get { return objetosTotales; } }

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

    public void SumarObjetos(int objetosAsumar)
    {
        objetosTotales += objetosAsumar;
        Debug.Log(objetosTotales);
    }

    #endregion
}





    
}
