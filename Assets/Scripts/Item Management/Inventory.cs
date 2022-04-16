using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private List<ItemManager> itemsList;

    public static Inventory instance;
    
    
    // Start is called before the first frame update
    void Start()
    {
        itemsList = new List<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {

        instance = this;

    }

    public void AddItems(ItemManager item)
    {
        if (item.isStackable)
        {
            bool itemAlreadyInInventory = false;
            
            foreach (ItemManager itemInInvetory in itemsList)
            {
                if (itemInInvetory.itemName == item.itemName)
                {
                    itemInInvetory.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            
            if (!itemAlreadyInInventory)
            {
                itemsList.Add(item);
            }
        }
        else
        {
            itemsList.Add(item);
        }
    }

    public void RemoveItem(ItemManager item)
    {
        if (item.isStackable)
        {
            ItemManager inventoryItem = null;

            foreach (ItemManager itemInInventory in itemsList)
            {
                if (itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.amount--;
                    inventoryItem = itemInInventory;
                }
            }

            if (inventoryItem != null && inventoryItem.amount <= 0)
            {
                print("remove 1");
                itemsList.Remove(inventoryItem);
            }
        }
        else
        {
            print("remove 2");
            itemsList.Remove(item);
        }
    }
    public List<ItemManager> GetItemList()
    {
        return itemsList;
    }
}
