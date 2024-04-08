using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta_NoLaEmpresa : MonoBehaviour
{
    private bool FinPartida = false;
    [SerializeField] private GameObject victory;
    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.GetComponent<GranjeroMovement>() && GameManager.Instance.cargandoOveja == true)
        {
            FinPartida = true;
            Debug.Log("Gnaste");
            victory.SetActive(true);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        victory.SetActive(false);
    }

    // Update is called once per frame

}
