using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUIPanel : UIPanel, IPointerClickHandler
{
    private CharacterInventory inventory;
    private ItemType currentItemType;
    [SerializeField] private TextMeshProUGUI menuText;

    [Space]
    [SerializeField] private Transform slotParent;
    [SerializeField] private InventoryItemSlot slotPrefab;

    [Space]
    [SerializeField] private ItemDescriptor itemDescriptor;

    private InventoryActionType[] actions;

    public void SetInventory(CharacterInventory inventory)
    {
        this.inventory = inventory;
    }

    public override void Show()
    {
        base.Show();

        currentItemType = ItemType.Equipment;
        DrawInventory();

        itemDescriptor.Hide();
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
            slot.Initialize();
            slot.SetInventoryItem(items[i]);
        }

        menuText.text = currentItemType.ToString();
    }

    public void SetInventoryAction(params InventoryActionType[] actions)
    {
        this.actions = actions;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject target = eventData.pointerCurrentRaycast.gameObject;
        if (target.TryGetComponent<InventoryItemSlot>(out InventoryItemSlot slot))
        {
            itemDescriptor.SetItem(slot.Item);
            foreach(InventoryActionType action in actions)
            {
                CreateActionButton(action, slot);
            }
            itemDescriptor.Show();
        }
    }

    private void CreateActionButton(InventoryActionType type, InventoryItemSlot itemSlot)
    {
        if (itemSlot == null)
            return;

        string text = "";
        Action action = null;

        switch (type)
        {
            case InventoryActionType.Equipment:
                {
                    text = "Hold";
                    action = () =>
                    {
                        CharacterHolder holder = inventory.Character.GetEntityComponent<CharacterHolder>();
                        if (holder == null)
                            return;

                        Item item = inventory.PopItem(itemSlot.Item);
                        if (item == null)
                            return;

                        IHold holdableObject = item.GetComponent<IHold>();
                        if (holdableObject == null)
                            return;

                        holder.Hold(holdableObject);

                        DrawInventory();

                        itemDescriptor.Hide();
                    };
                }
                break;
            case InventoryActionType.Remove:
                {
                    text = "Remove";
                    action = () =>
                    {
                        inventory.RemoveItem(itemSlot.Item);

                        DrawInventory();

                        itemDescriptor.Hide();
                    };
                }
                break;
            case InventoryActionType.Sell:
                {
                    //
                }
                break;
        }

        if (text == "" || action == null)
            return;

        itemDescriptor.CreateActionButton(text, action);
    }
}