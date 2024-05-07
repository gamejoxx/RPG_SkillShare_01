using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    public ItemsManager itemOnButton;

    public void Press ()
    {
        MenuManager.instance.itemName[0].text = itemOnButton.itemName;
        MenuManager.instance.itemDescription[0].text = itemOnButton.itemDescription;

        MenuManager.instance.activeItem = itemOnButton;

    }

}
