using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveCover : MonoBehaviour
{

    [SerializeField] private GameObject cubreCuevas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<GranjeroMovement>() != null)
        {
            //Debug.Log("GranjeroMovement no es null");
            if (cubreCuevas.active)
            {
                Debug.Log("cubreCuevas esta activo, debería desactivarse");
                cubreCuevas.SetActive(false);
            }
            else
            {
                Debug.Log("cubreCuevas esta inactivo, debería activarse");
                cubreCuevas.SetActive(true);
            }
        }
    }
}