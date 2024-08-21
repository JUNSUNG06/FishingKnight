using System;

[Serializable]
public class InventoryItem : IEquatable<Item>, IEquatable<InventoryItem>
{
    public ItemSO Info { get; private set; }

    private int count;
    public int Count => count;

    private bool isUnique;
    public bool IsUnique => isUnique;

    public InventoryItem(Item item)
    {
        Info = item.Info;

        count = 1;

        if (Info.ItemType == ItemType.Equipment)
            isUnique = true;
    }

    public InventoryItem(ItemSO info)
    {
        Info = info;

        count = 1;

        if (Info.ItemType == ItemType.Equipment)
            isUnique = true;
    }

    public void IncreaseCount()
    {
        count++;
    }

    public void DecreaseCount()
    {
        count--;
    }

    public bool Equals(Item other)
    {
        return Info == other.Info;
    }

    public bool Equals(InventoryItem other)
    {
        return Info == other.Info;
    }
}