using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUIPanel : UIPanel
{
    private CharacterInventory inventory;
    private ItemType currentItemType;
    [SerializeField] private TextMeshProUGUI menuText;

    [Space]
    [SerializeField] private Transform slotParent;
    [SerializeField] private InventoryItemSlot slotPrefab;

    public void SetInventory(CharacterInventory inventory)
    {
        this.inventory = inventory;
    }

    public override void Show()
    {
        base.Show();

        currentItemType = ItemType.Equipment;
        DrawInventory();
    }

    public void DrawNextItems()
    {
        currentItemType = (ItemType)(((int)currentItemType + 1) % (int)ItemType.Count);

        DrawInventory();
    }

    public void DrawBeforeItems()
    {
        currentItemType = (ItemType)(((int)currentItemType - 1 + (int)ItemType.Count) % (int)ItemType.Count);

        DrawInventory();
    }

    public void DrawInventory()
    {
        if (inventory == null)
            return;

        List<InventoryItem> items = inventory.ItemDictionary[currentItemType];

        for(int i = slotParent.childCount - 1; i >= 0; i--)
        {
            Destroy(slotParent.GetChild(i).gameObject);
        }

        for(int i = 0; i < items.Count; i++)
        {
            InventoryItemSlot slot = Instantiate(slotPrefab, slotParent);
            slot.SetInventoryItem(items[i]);
        }

        menuText.text = currentItemType.ToString();
    }
}
