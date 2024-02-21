using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpComponent : MonoBehaviour
{
    public int valor = 1;
    public GameManager gameManager;



    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            gameManager.SumarObjetos(valor);
            Destroy(this.gameObject);
        }
    }
}
