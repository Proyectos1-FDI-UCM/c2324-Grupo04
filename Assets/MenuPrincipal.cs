using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject _menuJugar;
    [SerializeField] private GameObject _menuNiveles;
    [SerializeField] private GameObject _menuAjustes;

    // Start is called before the first frame update
    void Start()
    {
        _menuJugar.SetActive(true);
        _menuNiveles.SetActive(false);
        _menuAjustes.SetActive(false);

    }

    public void ClickPlay()
    {
        _menuJugar.SetActive(false);
        _menuNiveles.SetActive(true);
    }

    public void ClickSettings()
    {
        _menuNiveles.SetActive(false);
        _menuAjustes.SetActive(true);
    }
}