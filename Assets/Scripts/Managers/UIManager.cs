using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool _paused = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Time.timeScale = 1.0f;
            _paused = false;
        }
        else
        {
            Debug.Log("PAUSA");
            Time.timeScale = 0.0f;
            _paused = true;
        }
    }
}
