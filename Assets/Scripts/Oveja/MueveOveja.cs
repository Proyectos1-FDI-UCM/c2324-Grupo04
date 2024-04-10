using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MueveOveja : MonoBehaviour
{
    #region references
    private Transform _myTransform;
    #endregion


    #region parameters
    
    #endregion


    #region variables
    
    #endregion








    #region methods

    void Start()
    {
        _myTransform = transform;
    }

    void Update()
    {
        
    }

    public void Lanzamiento()
    {

    }

    private void Fin()
    {
        this.enabled = false;
    }

    #endregion
}
