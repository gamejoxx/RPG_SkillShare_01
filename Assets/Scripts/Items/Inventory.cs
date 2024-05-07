using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private List<ItemsManager> itemsList;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        itemsList = new List<ItemsManager>();
        // Debug.Log("Inventory created");
    }


    public void AddItems(ItemsManager item)
    {
        print("Player picked up " + item.itemName);
        itemsList.Add(item);
        print("Inventory count: " + itemsList.Count);
    }

    public List<ItemsManager> GetItemsList()
    {
        return itemsList;
    }

}
