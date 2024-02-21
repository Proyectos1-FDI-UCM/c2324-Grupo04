using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI objetos;
  
    // Update is called once per frame
    void Update()
    {
        objetos.text = gameManager.ObjetosTotales.ToString();
    }
}
