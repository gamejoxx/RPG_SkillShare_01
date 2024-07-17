using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public string playerName;
    public Sprite characterImage;


    [SerializeField] int maxLevel = 20;
    public int playerLevel = 1;
    public int currentXP;
    public int[] xpForNextLevel;
    [SerializeField] int baseLevelXP;

    public int maxHP = 100;
    public int currentHP;

    public int maxMana = 30;
    public int currentMana;

    public int strength;
    public int defense;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        xpForNextLevel = new int[maxLevel];
        xpForNextLevel[1] = baseLevelXP;

        for(int i = 2; i < xpForNextLevel.Length; i++)
        {
            xpForNextLevel[i] = ((int)(0.02f * i * i * i + 3.06f * i * i + 105.6f * i));
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            AddXP(100);
        }
    }

    public void AddXP(int amountOfXp)
    {
        // Add the amount of XP to the player's current XP
        currentXP += amountOfXp;
        if(currentXP >= xpForNextLevel[playerLevel])
        {
            currentXP -= xpForNextLevel[playerLevel];
            playerLevel++;
            
            // Increase the player's strength and defense every other level
            if(playerLevel % 2 == 0)
            {
                strength++;
            }
            else
            {
                defense++;
            }

           // Increase the player's max HP and mana when they level up
            maxHP = Mathf.FloorToInt(maxHP * 1.18f);
            currentHP = maxHP;

            maxMana = Mathf.FloorToInt(maxMana * 1.06f);
            currentMana = maxMana;              


        }
    }

    public void AddHP(int amountHPToAdd)
    {
        currentHP += amountHPToAdd;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public void AddMana(int amountManaToAdd)
    {
        currentMana += amountManaToAdd;
        if(currentMana > maxMana)
        {
            currentMana = maxMana;
        }
    }

}
