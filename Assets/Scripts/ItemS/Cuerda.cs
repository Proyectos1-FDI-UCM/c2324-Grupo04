using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuerda : MonoBehaviour
{

    [SerializeField]
    private int _value = 1;

 
    private InventoryManager _inventoryManager;


    // Start is called before the first frame update
    void Start()
    {
        _inventoryManager = FindObjectOfType<InventoryManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D granjeroCollider)
    {
       if (granjeroCollider.gameObject.GetComponent<GranjeroMovement>() != null)
        {
            _inventoryManager.ChangeCantidadCuerda(_value); //
        } 
    }
}
