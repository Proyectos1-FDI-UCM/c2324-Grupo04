using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
//using UnityEditor.Animations;
using UnityEngine.Timeline;

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

		print("MenuPrincipal.Start" + playableDirector.name);
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
        Invoke("AuxClickSettings", 0.1f);
    }

    private void AuxClickSettings()
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

    public void ExitGame() 
    {
        Application.Quit();
    }


    public void CambiaNivel1()
    {
		SceneManager.LoadScene(1);
	}

    public void CambiaNivel2()
    {
		SceneManager.LoadScene(2);
	}

    public void CambiaTutorial()
    {
		SceneManager.LoadScene(3);
	}


}