using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int ObjetosTotales { get { return objetosTotales; } }
    private int objetosTotales;

    public void SumarObjetos(int objetosAsumar)
    {
        objetosTotales += objetosAsumar;
        Debug.Log(objetosTotales);
    }
}
