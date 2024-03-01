using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] 
    private string itemName;
    [SerializeField]
    private int quantity;
    [SerializeField]
    private Sprite sprite;
    private InventoryManager inventoryManager;


    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
    
    void OnTriggerEnter2D(Collider2D collision) // Se activa cuando �lgo colisiona con �l
    {

        GranjeroMovement granjeroMovement = collision.GetComponent<GranjeroMovement>(); // Busca un componente del tipo GranjeroMovement

        if (granjeroMovement != null) // Comprueba que granjeroMovement existe (y por tanto que lo que ha chocado es el granjero)
        {
            inventoryManager.AddItem(itemName, quantity, sprite);
            Destroy(gameObject);
        }
    }
}
