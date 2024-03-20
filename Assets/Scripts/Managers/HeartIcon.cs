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

    // Update is called once per frame
    void Update()
    {
        
    }
}