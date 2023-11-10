using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.ItemClasses;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory
{
    // TODO add max health potions to the upgrade shop and then update how many health potions the player can have
    private int maxHealthPotions = 4;
    private int coins = 0;
    private int startingCoins = 0;

    private List<WeaponItem> _equippedWeaponItems = new(2);
    private HyperAblilityItem _hyperAblilityItem;
    private List<ActiveAbilityItem> _equippedActiveAbilityItems = new(2);
    private List<PassiveAbilityItem> _equippedPassiveAbilityItems = new(2);

    public event Action<int> OnMoneyChange = delegate { };

    public Inventory()
    {
        Debug.Log(_equippedWeaponItems);
        Debug.Log("Inventory");
    }

    public void AddItem(Item item)
    {
        var weaponItem = item as WeaponItem;
        if (weaponItem.itemType == Item.ItemType.WeaponItem)
        {
            // add to empty weapon slot or try to replace a weapon in the slot
        }
        
        var abilityItem = item as AbilityItem;
        if (abilityItem.itemType == Item.ItemType.WeaponItem)
        {
            var activeAbilityItem = item as ActiveAbilityItem;
            if (activeAbilityItem.abilityItemType == AbilityItem.AbilityItemType.ActiveAbilityItem)
            {
                // add to empty active ability slot or try to replace an active ability in the slot
            }
            
            var passiveAbilityItem = item as PassiveAbilityItem;
            if (passiveAbilityItem.abilityItemType == AbilityItem.AbilityItemType.PassiveAbilityItem)
            {
                // add to empty passive ability slot or try to replace a passive ability in the slot
            }
            
            var hyperAbilityItem = item as HyperAblilityItem;
            if (hyperAbilityItem.abilityItemType == AbilityItem.AbilityItemType.HyperAbilityItem)
            {
                // add to empty hyper ability slot or try to replace a hyper ability in the slot
                if (_hyperAblilityItem.Equals(null))
                {
                    _hyperAblilityItem = hyperAbilityItem;
                }
                else
                {
                    // replace hyper ability
                }
            }
        }
    }



    public bool RemoveItem(Item item)
    {
        return false;
    }

    public void AddCoins(int newCoins)
    {
        coins += newCoins;
        OnMoneyChange(coins);
    }

    public bool RemoveCoins(int newCoins)
    {
        if (coins - newCoins < 0)
        {
            Debug.Log("Not enough coins");
            return false;
        }

        coins -= newCoins;
        OnMoneyChange(coins);
        return true;
    }
    public int GetCoins()  {
        return startingCoins;
    }
}