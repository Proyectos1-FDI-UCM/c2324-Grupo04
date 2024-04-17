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
            if (cubreCuevas.active)
            {
                cubreCuevas.SetActive(false);
            }
            else
            {
                cubreCuevas.SetActive(true);
            }
        }
    }
}
