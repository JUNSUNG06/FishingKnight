using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRob : Equipment
{
    [SerializeField] private Socket needleSocket;
    private Item stuckedItem;
    public Item StuckedItem => stuckedItem;

    public event Action<Item> OnItemStucked;

    public void StuckItem(Item item)
    {
        if (item == null)
            return;

        stuckedItem = item;

        item.transform.SetParent(needleSocket.transform);
        item.transform.localPosition = Vector3.zero;

        needleSocket.Use(item.gameObject);

        OnItemStucked?.Invoke(item);
    }

    public void ClearNeedle()
    {
        if (stuckedItem == null)
            return;

        Destroy(stuckedItem.gameObject);
        stuckedItem = null;
        needleSocket.Unuse();
    }
}
