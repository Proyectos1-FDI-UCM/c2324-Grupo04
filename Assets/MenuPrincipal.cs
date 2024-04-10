using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject _menuJugar;
    [SerializeField] private GameObject _menuNiveles;
    [SerializeField] private GameObject _menuAjustes;
    [SerializeField] private PlayableDirector playableDirector;

    public GameObject selectplay, selectlevel1, exitSettings, enterSettings;


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
        playableDirector.Play();
    }

    public void ClickPlay()
    {
        _menuJugar.SetActive(false);
        _menuNiveles.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(selectlevel1);

    }

    public void ClickSettings()
    {
        _menuNiveles.SetActive(false);
        _menuAjustes.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(enterSettings);
    }

    public void ExitSettings() 
    {
        _menuAjustes.SetActive(false);
        _menuNiveles.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(exitSettings);
    }


    public void CambiaNivel1()
    {
        SceneManager.LoadScene(1);
    }


}