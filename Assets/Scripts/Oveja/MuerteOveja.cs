using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MueveOveja : MonoBehaviour
{
    #region references
    private Transform _myTransform;

    [SerializeField] private GameObject menuMuerte;
    [SerializeField] private GameObject reset;
    #endregion


    #region parameters

    #endregion


    #region variables

    #endregion

    #region methods

    void Start()
    {
        _myTransform = transform;

        menuMuerte.SetActive(false);
    }

    void Update()
    {
        
    }

    private void Fin()
    {
        this.enabled = false;
    }

    public void Die()
    {

        menuMuerte.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(reset);
        Time.timeScale = 0f;
        
    }

    #endregion
}
