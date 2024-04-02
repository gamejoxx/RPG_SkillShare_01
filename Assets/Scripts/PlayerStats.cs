using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] string playerName;

    [SerializeField] int maxLevel = 20;
    [SerializeField] int playerLevel = 1;
    [SerializeField] int currentXP;
    [SerializeField] int[] xpForEachLevel;
    [SerializeField] int baseLevelXP;

    [SerializeField] int maxHP = 100;
    [SerializeField] int currentHP;

    [SerializeField] int maxMana = 30;
    [SerializeField] int currentMana;

    [SerializeField] int strength;
    [SerializeField] int defense;


    // Start is called before the first frame update
    void Start()
    {
        xpForEachLevel = new int[maxLevel];
        xpForEachLevel[1] = baseLevelXP;

        for(int i = 2; i < xpForEachLevel.Length; i++)
        {
            xpForEachLevel[i] = ((int)(0.02f * i * i * i + 3.06f * i * i + 105.6f * i));
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
