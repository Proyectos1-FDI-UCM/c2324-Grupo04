using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranjeroAnimator : MonoBehaviour
{
    #region references
    private Transform _myTransform;
    #endregion


    #region parameters
    #endregion


    #region variables
    private bool miraDer = true;
    #endregion








    #region methods
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
    }



    public void Gira(float dir)
    {        
        if (miraDer && dir > 0)
        {
            print("Giro izq");
            _myTransform.localScale = Vector3.one;
            miraDer = false;
        }
        else if (!miraDer && dir < 0)
        {
            print("Giro der");
            _myTransform.localScale = new Vector3(-1, 1, 1);
            miraDer = true;
        }
    }

    public void Ataca()
    {
        print("Ataca (animación)");
    }

    public void SueltaObjeto()
    {
        print("Suelta objeto (animación)");
    }
    #endregion


    #region plantillas
    // _animator
    #endregion

}
