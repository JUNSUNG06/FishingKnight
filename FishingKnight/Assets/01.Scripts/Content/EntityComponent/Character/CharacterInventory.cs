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

        itemDictionary[inventoryItem.Itemtype].Add(inventoryItem);
        Destroy(item.gameObject);
    }

    public Item PopItem(InventoryItem inventoryItem)
    {
        Item item = Instantiate(inventoryItem.Prefab);

        RemoveItem(item);

        return item;
    }

    public void RemoveItem(Item item)
    {
        if (item == null)
            return;

        InventoryItem inventoryItem = itemDictionary[item.Itemtype].Find(x => x.Equals(item));
        if (inventoryItem == null)
            return;

        itemDictionary[item.Itemtype].Remove(inventoryItem);
    }
}