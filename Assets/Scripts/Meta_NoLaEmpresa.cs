using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta_NoLaEmpresa : MonoBehaviour
{
    private bool FinPartida = false;
    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.GetComponent<OvejaInteraction>())
        {
            FinPartida = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
