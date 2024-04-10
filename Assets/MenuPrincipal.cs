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
        playableDirector.Play();
    }

    public void ClickPlay()
    {
        _menuJugar.SetActive(false);
        _menuNiveles.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        Debug.Log(EventSystem.current.alreadySelecting);
        EventSystem.current.SetSelectedGameObject(selectlevel1);
        Debug.Log(EventSystem.current.alreadySelecting);

    }

    public void ClickSettings()
    {
        _menuNiveles.SetActive(false);
        _menuAjustes.SetActive(true);
    }


    public void CambiaNivel1()
    {
        SceneManager.LoadScene(1);
    }


}