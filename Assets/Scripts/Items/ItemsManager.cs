using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public enum ItemType { Item, Weapon, Armor }
    public ItemType itemType;

    public string itemName, itemDescription;
    public int valueInCoins;
    public Sprite itemsImage;

    public enum Affecttype { HP, Mana }
    public int amountOfAffect;
    public Affecttype affectType;

    public int weaponStrength;
    public int armorDefense;

    public bool isStackable;
    public int amount;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Player"))
        {
            // print("Player picked up " + itemName);
            Inventory.instance.AddItems(this);
            gameObject.SetActive(false);
        }
    }

}
