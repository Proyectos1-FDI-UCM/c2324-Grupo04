using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MuerteJugador : MonoBehaviour
{
    [SerializeField] private GameObject menuMuerte;
    [SerializeField] private GameObject reset;
    //public GameObject canvasMuerte;
    void Start()
    {
        menuMuerte.SetActive(false);
    }
    public void Die()
    {
       
        menuMuerte.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(reset);
        Time.timeScale = 0f;
        //GameManager.Instance.ReiniciaEscena();
        /* canvasMuerte.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("El jugador ha muerto.");
        */
    }
}
