using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlot : UIObject
{
    private InventoryItem item;

    [SerializeField] private Image icon;

    public void SetInventoryItem(InventoryItem item)
    {
        this.item = item;

        icon.sprite = item.Info.Icon;
    }
}