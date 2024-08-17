using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : CharacterComponent
{
    private Dictionary<ItemType, List<InventoryItem>> itemDictionary;
    public Dictionary<ItemType, List<InventoryItem>> ItemDictionary => itemDictionary;

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        itemDictionary = new Dictionary<ItemType, List<InventoryItem>>();
        foreach (ItemType type in Enum.GetValues(typeof(ItemType)))
            itemDictionary.Add(type, new List<InventoryItem>());
    }

    public void AddItem(Item item)
    {
        if (item == null)
            return;

        InventoryItem inventoryItem = new InventoryItem(item);

        if (ItemDictionary[inventoryItem.Info.ItemType].Contains(inventoryItem))
        {
            if(inventoryItem.IsUnique == false)
            {
                ItemDictionary[inventoryItem.Info.ItemType].Find(x => x.Equals(inventoryItem)).IncreaseCount();
            }
        }
        else
        {
            itemDictionary[inventoryItem.Info.ItemType].Add(inventoryItem);
        }
        
        Destroy(item.gameObject);
    }

    public Item PopItem(InventoryItem inventoryItem, Entity owner = null)
    {
        Item item = Instantiate(inventoryItem.Info.Prefab);
        item.SetOwner(owner);

        RemoveItem(item);

        return item;
    }

    public void RemoveItem(Item item)
    {
        if (item == null)
            return;

        InventoryItem inventoryItem = itemDictionary[item.Info.ItemType].Find(x => x.Equals(item));
        if (inventoryItem == null)
            return;

        inventoryItem.DecreaseCount();

        if(inventoryItem.Count <= 0)
            itemDictionary[item.Info.ItemType].Remove(inventoryItem);
    }

    public void RemoveItem(InventoryItem item)
    {
        if (item == null) 
            return;

        item.DecreaseCount();

        if (item.Count <= 0)
            itemDictionary[item.Info.ItemType].Remove(item);
    }
}