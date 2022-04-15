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
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
