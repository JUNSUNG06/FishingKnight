using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Item")]
public class ItemSO : ScriptableObject
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private Item prefab;
    [SerializeField] private Sprite icon;
    [SerializeField] private Sprite itemImage;
    [SerializeField] private string itemName;
    [TextArea][SerializeField] private string description;

    public ItemType ItemType => itemType;
    public Item Prefab => prefab;
    public Sprite Icon => icon;
    public Sprite ItemImage => itemImage;
    public string ItemName => itemName;
    public string Description => description;
}