using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Item")]
public class ItemSO : ScriptableObject
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private Item prefab;
    [SerializeField] private Sprite icon;

    public ItemType ItemType => itemType;
    public Item Prefab => prefab;
    public Sprite Icon => icon;
}