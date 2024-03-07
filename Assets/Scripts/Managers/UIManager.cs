using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region references

    [SerializeField] GameObject _menuDePausa;
    #endregion 

    private bool _paused = false;
    // Start is called before the first frame update
    void Start()
    {
        _menuDePausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPause()
    {
        
        if (_paused)
        {
            Debug.Log("Salida de pausa");
            _menuDePausa.SetActive(false);
            Time.timeScale = 1.0f;
            _paused = false;
        }
        else
        {
            Debug.Log("PAUSA");
            _menuDePausa.SetActive(true);
            Time.timeScale = 0.0f;
            _paused = true;
        }
    }
}
