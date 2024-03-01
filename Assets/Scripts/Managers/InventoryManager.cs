using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject InventoryMenu;
    private bool menuActive = false;
    public ItemSlot[] itemSlot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && menuActive)
        {
            Debug.Log("e");
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActive = false;
        }
        else if (Input.GetKeyDown("e") && !menuActive)
        {
            Debug.Log("e");
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActive = true;
        }
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, quantity, itemSprite);
                return;
            }
        }
    }
}
