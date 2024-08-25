using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class InventoryUIPanel : UIPanel, IPointerClickHandler
{
    private CharacterInventory inventory;
    private Entity opener;
    private ItemType currentItemType;
    [SerializeField] private TextMeshProUGUI menuText;

    [Space]
    [SerializeField] private Transform slotParent;
    [SerializeField] private InventoryItemSlot slotPrefab;

    [Space]
    [SerializeField] private ItemDescriptor itemDescriptor;

    private InventoryActionType[] actions;

    public void SetInventory(Entity opener, CharacterInventory inventory)
    {
        this.inventory = inventory;
        this.opener = opener;
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

        slotParent.ClearChild();

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
            itemDescriptor.ClearActionButton();
            foreach(InventoryActionType action in actions)
            {
                CreateActionButton(action, slot);
            }
            itemDescriptor.SetItem(slot.Item);
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
            case InventoryActionType.Hold:
                {
                    CharacterHolder holder = inventory.Character.GetEntityComponent<CharacterHolder>();
                    if (holder == null)
                        return;

                    IHold holdableObject = itemSlot.Item.Info.Prefab.GetComponent<IHold>();
                    if (holdableObject == null)
                        return;

                    text = "Hold";
                    action = () =>
                    {
                        Item item = inventory.PopItem(itemSlot.Item, inventory.Character);
                        holdableObject = item.GetComponent<IHold>();

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

                        if(itemSlot.Item.Count == 0)
                            itemDescriptor.Hide();
                    };
                }
                break;
            case InventoryActionType.Sell:
                {
                    CharacterWallet wallet = inventory.Character.GetEntityComponent<CharacterWallet>();
                    if (wallet == null)
                        return;

                    CharacterInventory openerInventory = opener.GetEntityComponent<CharacterInventory>();
                    if (openerInventory == null)
                        return; 

                    text = "Sell";
                    action = () =>
                    {
                        wallet.AddMoeny(itemSlot.Item.Info.Price);
                        
                        inventory.RemoveItem(itemSlot.Item);//player
                        
                        DrawInventory();

                        if (itemSlot.Item.Count == 0)
                        {
                            itemDescriptor.Hide();
                            //itemSlot.Item.IncreaseCount();
                        }

                        InventoryItem sellItem = new InventoryItem(itemSlot.Item.Info);
                        openerInventory.AddItem(sellItem);//npc
                    };
                }
                break;
            case InventoryActionType.Buy:
                {
                    CharacterWallet wallet = opener.GetEntityComponent<CharacterWallet>();
                    if (wallet == null)
                        return;

                    CharacterInventory openerInventory = opener.GetEntityComponent<CharacterInventory>();
                    if(openerInventory == null) 
                        return;

                    text = "Buy";
                    action = () =>
                    {
                        if (wallet.Money < itemSlot.Item.Info.Price)
                            return;

                        wallet.RemoveMoney(itemSlot.Item.Info.Price);

                        inventory.RemoveItem(itemSlot.Item);//npc
                        
                        DrawInventory();

                        if (itemSlot.Item.Count == 0)
                        {
                            itemDescriptor.Hide();
                            //itemSlot.Item.IncreaseCount();
                        }

                        InventoryItem buyItem = new InventoryItem(itemSlot.Item.Info);
                        openerInventory.AddItem(buyItem);//player
                    };
                }
                break;
        }

        if (text == "" || action == null)
            return;
        
        itemDescriptor.CreateActionButton(text, action);
    }
}