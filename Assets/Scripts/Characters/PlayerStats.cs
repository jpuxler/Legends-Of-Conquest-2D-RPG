using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public string playerName;

    [SerializeField] public Sprite characterImage;

    [SerializeField] public int maxLevel = 50;
    [SerializeField] public int playerLevel = 1;
    [SerializeField] public int currentXP;
    [SerializeField] public int[] xpForEachLevel;
    [SerializeField] public int baseLevelXP = 100;
    
    [SerializeField] public int maxHp = 100;
    [SerializeField] public int currentHP;

    [SerializeField] public int maxMana = 30;
    [SerializeField] public int currentMana;

    [SerializeField] public int dexterity;
    [SerializeField] public int defence;
    
    
    // Start is called before the first frame update
    void Start()
    {
        xpForEachLevel = new int[maxLevel];
        xpForEachLevel[1] = baseLevelXP;

        for (int i = 2; i < xpForEachLevel.Length; i++)
        {
            xpForEachLevel[i] = (int)(0.02f * i * i * i + 3.06f * i * i + 105.6f * i);
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
        currentXP += amountOfXp;
        if (currentXP > xpForEachLevel[playerLevel])
        {
            currentXP -= xpForEachLevel[playerLevel];
            playerLevel++;

            if (playerLevel % 2 == 0)
            {
                dexterity++;
            }
            else
            {
                defence++;
            }

            maxHp = (int) (maxHp * 1.06f);
            currentHP = maxHp;
            maxMana = (int) (maxMana * 1.06f);
            currentMana = maxMana;
        }
    }
    
    
    
}
