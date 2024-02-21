using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region properties
    

    static private GameManager _instance;
    

    static public GameManager Instance // Todos pod�is usar este m�todo (escrito: GameManager.Instance) para acceder al GameManager y a cualquiera de sus m�todos
    {
        get { return _instance; }
    }

    private int objetosTotales;

    public int ObjetosTotales { get { return objetosTotales; } }

    #endregion
    #region methods

    private void Awake()
    {
        if (_instance == null) _instance = this; // S�lo queremos un GameManager, as� que usamos el patr�n singleton
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
