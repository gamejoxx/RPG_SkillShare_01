using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MenuManager : MonoBehaviour
{
    [SerializeField] Image imageToFade;
    [SerializeField] GameObject menu;

    [SerializeField] GameObject[] statsButton;

    public static MenuManager instance;

    private PlayerStats[] playerStats;
    [SerializeField] TextMeshProUGUI[] nameText, hpText, manaText, currentXPText, xpText;
    [SerializeField] Slider[] xpSlider;
    [SerializeField] Image[] chracterImage;
    [SerializeField] GameObject[] characterPanel;

    [SerializeField] TextMeshProUGUI[] statName, statHP, statMana, statStr, statDef;
    [SerializeField] Image characterStatImage;

    [SerializeField] GameObject itemSlotContainer;
    [SerializeField] Transform itemSlotContainerParent;

    private void Start()
    {
        instance = this;
    }


    public void Update()
    {
    
        if(Input.GetKeyDown(KeyCode.M))
        {
            if(menu.activeInHierarchy)
            {
                menu.SetActive(false);
                GameManager.instance.gameMenuOpen = false;
            }
            else
            {
                UpdateStats();
                menu.SetActive(true);
                GameManager.instance.gameMenuOpen = true;
            }
        }
    
    }

    public void UpdateStats()
    {
        playerStats = GameManager.instance.GetPlayerStats();

        for(int i = 0; i < playerStats.Length; i++)
        {            
            characterPanel[i].SetActive(true);

            nameText[i].text = playerStats[i].playerName;
            hpText[i].text = "HP: " + playerStats[i].currentHP + "/" + playerStats[i].maxHP;
            manaText[i].text = "Mana: " + playerStats[i].currentMana + "/" + playerStats[i].maxMana;
            currentXPText[i].text = "Current XP: " + playerStats[i].currentXP;

            chracterImage[i].sprite = playerStats[i].characterImage;

            xpText[i].text = playerStats[i].currentXP.ToString() + "/" + playerStats[i].xpForNextLevel[playerStats[i].playerLevel];
            xpSlider[i].maxValue = playerStats[i].xpForNextLevel[playerStats[i].playerLevel];
            xpSlider[i].value = playerStats[i].currentXP;

        }
    }
   
    public void StatsMenu()
    {
        for(int i = 0; i < playerStats.Length; i++)
        {
            statsButton[i].SetActive(true);

            statsButton[i].GetComponentInChildren<TextMeshProUGUI>().text = playerStats[i].playerName;

        }

        StatsMenuUpdate(0);

    }

    public void StatsMenuUpdate(int playerSelectedNumber)
    {
        //// Check if the playerSelectedNumber is within bounds of the playerStats array
        //if (playerSelectedNumber < 0 || playerSelectedNumber >= playerStats.Length)
        //{
        //    Debug.LogError("Player selected number is out of range.");
        //    return; // Exit the method to prevent accessing an invalid array index
        //}

        PlayerStats playerSelected = playerStats[playerSelectedNumber];

        statName[0].text = playerSelected.playerName;

        statHP[0].text = playerSelected.currentHP.ToString() + "/" + playerSelected.maxHP;
        statMana[0].text = playerSelected.currentMana.ToString() + "/" + playerSelected.maxMana;

        statStr[0].text = playerSelected.strength.ToString();
        statDef[0].text = playerSelected.defense.ToString();

        characterStatImage.sprite = playerSelected.characterImage;
    }

    public void UpdatesItemsInventory()
    {
        foreach (Transform itemSlot in itemSlotContainerParent)
        {
            Destroy(itemSlot.gameObject);
        }

        foreach (ItemsManager item in Inventory.instance.GetItemsList())
        {
            RectTransform itemSlot = Instantiate(itemSlotContainer, itemSlotContainerParent).GetComponent<RectTransform>();
            Image itemImage = itemSlot.Find("Items Image").GetComponent<Image>();
            itemImage.sprite = item.itemsImage;

            TextMeshProUGUI itemsAmountText = itemSlot.Find("Amount Text").GetComponent<TextMeshProUGUI>();

            if (item.amount > 1)
            {
                itemsAmountText.text = item.amount.ToString();
            }
            else
            {
                itemsAmountText.text = "";
            }

        }
              
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }



    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("StartFading");
    }


}
