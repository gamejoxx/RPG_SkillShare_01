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

    public void UsreItem()
    {
        if (itemType == ItemType.Item)
        {
            if(affectType == Affecttype.HP)
            {
                PlayerStats.instance.AddHP(amountOfAffect);
            }
            else if(affectType == Affecttype.Mana)
            {
                PlayerStats.instance.AddMana(amountOfAffect);
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Player"))
        {
            Inventory.instance.AddItems(this);
            SelfDestroy();
        }
    }

    public void SelfDestroy()
    {
        gameObject.SetActive(false);
    }
}
