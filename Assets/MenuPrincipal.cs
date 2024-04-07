using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject _menuJugar;
    [SerializeField] private GameObject _menuNiveles;
    [SerializeField] private GameObject _menuAjustes;
    public GameObject selectplay, selectlevel1;


    // Start is called before the first frame update
    void Awake()
    {
        _menuJugar.SetActive(true);
        _menuNiveles.SetActive(false);
        _menuAjustes.SetActive(false);
    }
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(selectplay);
    }

    public void ClickPlay()
    {
        _menuJugar.SetActive(false);
        _menuNiveles.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(selectplay);

    }

    public void ClickSettings()
    {
        _menuNiveles.SetActive(false);
        _menuAjustes.SetActive(true);
    }


}