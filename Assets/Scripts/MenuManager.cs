using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private Image imageToFade;
    [SerializeField] private GameObject menu;

    [SerializeField] private GameObject[] statsButtons;

    private PlayerStats[] playerStats;
    [SerializeField] private TextMeshProUGUI[] nameText, hpText, manaText, currentXpText, xpText;
    [SerializeField] private Slider[] xpSlider;
    [SerializeField] private Image[] characterImage;
    [SerializeField] private GameObject[] characterPanel;

    [SerializeField] private TextMeshProUGUI statName, statHP, statMana, statDex, statDef;
    [SerializeField] private Image statCharacterImage;

    [SerializeField] private GameObject itemSlotContainer;
    [SerializeField] private Transform itemSlotContainerParent;


    public TextMeshProUGUI itemName, itemDescription;

    public ItemManager activeItem;

    private Animator animator;

    public static MenuManager instance;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UpdateStats();
            GameManager.instance.gameMenuOpened = !GameManager.instance.gameMenuOpened;
            menu.SetActive(!menu.activeInHierarchy);
        }
    }

    public void UpdateStats()
    {
        playerStats = GameManager.instance.GetPlayerStats();

        for (int i = 0; i < playerStats.Length; i++)
        {
            characterPanel[i].gameObject.SetActive(true);

            nameText[i].text = playerStats[i].playerName;
            hpText[i].text = "HP: " + playerStats[i].currentHP + "/" + playerStats[i].maxHp;
            manaText[i].text = "Mana: " + playerStats[i].currentMana + "/" + playerStats[i].maxMana;
            currentXpText[i].text = "Current XP: " + playerStats[i].currentXP;
            xpText[i].text = playerStats[i].currentXP + "/" + playerStats[i].xpForEachLevel[playerStats[i].playerLevel];


            xpSlider[i].maxValue = playerStats[i].xpForEachLevel[playerStats[i].playerLevel];
            xpSlider[i].value = playerStats[i].currentXP;
            
            
            
            characterImage[i].sprite = playerStats[i].characterImage;
        }
        
    }

    public void StatsMenu()
    { 
        for (int i = 0; i < playerStats.Length; i++)
        {
            statsButtons[i].SetActive(true);

            statsButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = playerStats[i].playerName;

        }
        
        StatsMenuUpdate(0);
    }

    public void StatsMenuUpdate(int playerSelectedNumber)
    {
        PlayerStats playerSelected = playerStats[playerSelectedNumber];
        statName.text = playerSelected.playerName;
        statHP.text = playerSelected.currentHP + "/" + playerSelected.maxHp;
        statMana.text = playerSelected.currentMana + "/" + playerSelected.maxMana;

        statDex.text = playerSelected.dexterity.ToString();
        statDef.text = playerSelected.defence.ToString();

        statCharacterImage.sprite = playerSelected.characterImage;
    }

    public void UpdateItemsInventory()
    {
        foreach (Transform itemSlot in itemSlotContainerParent)
        {
            Destroy(itemSlot.gameObject);
        }
        foreach (ItemManager item in Inventory.instance.GetItemList())
        {
            RectTransform itemSlot = Instantiate(itemSlotContainer, itemSlotContainerParent).GetComponent<RectTransform>();
            Image itemImage = itemSlot.Find("ItemsImage").GetComponent<Image>();
            itemImage.sprite = item.itemImage;

            TextMeshProUGUI itemsAmountText = itemSlot.Find("AmountText").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1)
            {
                itemsAmountText.text = item.amount.ToString();
            }
            else
            {
                itemsAmountText.text = "";
            }

            itemSlot.GetComponent<ItemButton>().itemOnButton = item;
        }
    }

    public void DiscardItem()
    {
        Inventory.instance.RemoveItem(activeItem);
        UpdateItemsInventory();
    }

    public void UseItem()
    {
        activeItem.UseItem();
        DiscardItem();
    }

    public void FadeImage()
    {
        animator = imageToFade.GetComponent<Animator>();
        animator.SetTrigger("StartFade");
    }

    public void QuitGame()
    {
        Debug.Log("We've quit the game");
        Application.Quit();
    }
}
