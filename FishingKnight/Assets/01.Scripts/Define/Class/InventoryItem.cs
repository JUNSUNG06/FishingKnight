using System;

[Serializable]
public class InventoryItem : IEquatable<Item>
{
    public ItemSO Info { get; private set; }

    public InventoryItem(Item item)
    {
        Info = item.Info;
    }

    public bool Equals(Item other)
    {
        return Info == other.Info;
    }
}