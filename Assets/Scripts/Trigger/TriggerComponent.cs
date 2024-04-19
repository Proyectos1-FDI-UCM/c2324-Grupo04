using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerComponent : MonoBehaviour
{
    #region variables

    #endregion


    #region references
    [SerializeField]
    private GameObject _deactivatedObject;


    #endregion

    void OnTriggerEnter2D(Collider2D collision)
    {
        GranjeroMovement granjeroMovement = collision.GetComponent<GranjeroMovement>();
        if (granjeroMovement != null)
        {
            print("Has entrado en un trigger");
            _deactivatedObject.SetActive(false);
        }
    }
}
