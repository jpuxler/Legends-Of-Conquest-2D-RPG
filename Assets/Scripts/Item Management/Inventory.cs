using System.Collections;
using System.Collections.Generic;
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
        print(item.itemName + " has been added to inventory");
        itemsList.Add(item);
        print(itemsList.Count);
    }

    public List<ItemManager> GetItemList()
    {
        return itemsList;
    }
}
