using System;

[Serializable]
public class InventoryItem : IEquatable<Item>
{
    public Item Prefab { get; private set; }
    public ItemType Itemtype { get; private set; }

    public InventoryItem(Item item)
    {
        Prefab = item.Prefab;
        Itemtype = item.Itemtype;
    }

    public bool Equals(Item other)
    {
        return (Prefab == other.Prefab) && (Itemtype == other.Itemtype);
    }
}