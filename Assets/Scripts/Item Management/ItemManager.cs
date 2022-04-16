using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public enum ItemType
    {
        Item, Weapon, Armor
    }

    public ItemType itemType;

    public string itemName, itemDescription;
    public int valueInCoins;
    public Sprite itemImage;


    public enum AffectType
    {
        HP, Mana
    }

    public int amountOfAffect;
    public AffectType affectType;

    public int weaponDexterity;
    public int armorDefence;

    public bool isStackable;
    public int amount;


    public void UseItem()
    {
        if (itemType == ItemType.Item)
        {
            if (affectType == AffectType.HP)
            {
                PlayerStats.instance.AddHP(amountOfAffect);
            }else if (affectType == AffectType.Mana)
            {
                PlayerStats.instance.AddMana(amountOfAffect);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Inventory.instance.AddItems(this);
            SelfDestroy();
        }
    }

    public void SelfDestroy()
    {
        this.gameObject.SetActive(false);
    }
}
