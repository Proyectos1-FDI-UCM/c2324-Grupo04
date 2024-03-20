using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartIcon : MonoBehaviour
{
    #region references
    [SerializeField]
    private Sprite entero;
    [SerializeField]
    private Sprite medio;
    [SerializeField]
    private Sprite vacio;

    [SerializeField]
    private SpriteRenderer _mySpriteRenderer;
    #endregion

    #region properties

    private Estado estado = Estado.Desactivado;

    #endregion




    public enum Estado
    {
        Entero,
        Medio,
        Vacio,
        Desactivado
    }


    // Start is called before the first frame update
    void Start()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log("Coraz�n Start()");
        if (_mySpriteRenderer != null)
        {
            Debug.Log("_mySpriteRenderer del coraz�n se ha pillado bien");
        }
        //if (_mySpriteRenderer == null)
        //{
        //    Debug.Log("_mySpriteRenderer del coraz�n no se ha pillado");
        //}
        Desactivar();
        //if (estado == Estado.Entero)
        //{
        //    Debug.Log("Coraz�n: Est� encendido");
        //}
        //else if (estado == Estado.Desactivado)
        //{
        //    Debug.Log("Coraz�n: Est� apagado");
        //}
    }

    public void Inicializacion()
    {
        Debug.Log("Coraz�n inicializado");
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        if ( _mySpriteRenderer != null )
        {
            Debug.Log("_mySpriteRenderer del coraz�n no es null");
        }
        if (_mySpriteRenderer == null)
        {
            Debug.Log("_mySpriteRenderer del coraz�n no se ha pillado");
        }
    }

    public void Actualiza()
    {
        if (estado == Estado.Desactivado)
        {
            _mySpriteRenderer.enabled = false;
        }
        else
        {
            _mySpriteRenderer.enabled = true;
            if (estado == Estado.Entero)
            {
                _mySpriteRenderer.sprite = entero;
            }
            else if (estado == Estado.Medio)
            {
                _mySpriteRenderer.sprite = medio;
            }
            else
            {
                _mySpriteRenderer.sprite = vacio;
            }
        }
        
    }

    public void Entero()
    {
        Debug.Log("Coraz�n Entero()");
        _mySpriteRenderer.enabled = true;   
        _mySpriteRenderer.sprite = entero;
        estado = Estado.Entero;
    }

    public void Medio()
    {
        _mySpriteRenderer.enabled = true;
        _mySpriteRenderer.sprite = medio;
        estado = Estado.Medio;
    }

    public void Vacio()
    {
        _mySpriteRenderer.enabled = true;
        _mySpriteRenderer.sprite = vacio;
        estado = Estado.Vacio;
    }

    public void Desactivar()
    {
        _mySpriteRenderer.enabled = false;
        estado = Estado.Desactivado;
    }

    public Estado VerEstado()
    {
        return estado;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
