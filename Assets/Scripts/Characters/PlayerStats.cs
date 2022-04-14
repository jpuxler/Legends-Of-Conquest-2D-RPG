using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private string playerName;

    [SerializeField] private int maxLevel = 50;
    [SerializeField] private int playerLevel = 1;
    [SerializeField] private int currentXP;
    [SerializeField] private int[] xpForEachLevel;
    [SerializeField] private int baseLevelXP = 100;
    
    [SerializeField] private int maxHp = 100;
    [SerializeField] private int currentHP;

    [SerializeField] private int maxMana = 30;
    [SerializeField] private int currentMana;

    [SerializeField] private int dexterity;
    [SerializeField] private int defence;
    
    
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
        }
    }
}
