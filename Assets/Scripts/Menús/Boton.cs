using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    #region references
    [SerializeField]
    private Sprite _encendido;
    [SerializeField]
    private Sprite _apagado;




    private SpriteRenderer _mySR;
    #endregion


    #region parameters
    #endregion


    #region variables
    private bool _seleccionado = false;
    #endregion


    #region methods
    public void Enciende()
    {
        _seleccionado = true;
        _mySR.sprite = _encendido;
    }

    public void Apaga()
    {
        _seleccionado = false;
        _mySR.sprite = _apagado;
    }
    #endregion




    // Start is called before the first frame update
    void Start()
    {
        _mySR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
