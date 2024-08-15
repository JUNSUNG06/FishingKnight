using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemSlot : UIObject
{
    private InventoryItem item;

    public void SetInventoryItem(InventoryItem item)
    {
        this.item = item;
    }
}