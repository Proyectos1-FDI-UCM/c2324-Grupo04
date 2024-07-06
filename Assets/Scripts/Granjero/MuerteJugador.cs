using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MuerteJugador : MonoBehaviour
{
    [SerializeField] private GameObject menuMuerte;
    [SerializeField] private GameObject reset;
    void Start()
    {
        menuMuerte.SetActive(false);
    }
    private void Die()
    {
        menuMuerte.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(reset);
        Time.timeScale = 0f;
    }
}
