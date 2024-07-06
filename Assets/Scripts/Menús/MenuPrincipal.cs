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
    [SerializeField] private PlayableDirector playableDirector;

    public GameObject selectplay, selectlevel1, exitSettings;

    // Start is called before the first frame update
    void Awake()
    {
        _menuJugar.SetActive(true);
        _menuNiveles.SetActive(false);
    }
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(selectplay);
    }

    public void ClickPlay()
    {
        Invoke("AuxClickPlay", 0.15f);
    }

    public void AuxClickPlay()
    {
        _menuJugar.SetActive(false);
        _menuNiveles.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(selectlevel1);

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

    public void CambiaPrueba()
    {
        SceneManager.LoadScene(4);
    }

    public void Tiempo1()
    {
        Time.timeScale = 1f;
    }


}