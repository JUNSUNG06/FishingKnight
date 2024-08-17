using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoldItemUIPanel : UIPanel, IPointerClickHandler
{
    private CharacterHolder holder;

    [SerializeField] private Transform itemSctionTrm;

    [Space]
    [SerializeField] private ItemDescriptor itemDescriptor;

    public override void Show()
    {
        base.Show();

        DrawItemSlot();

        itemDescriptor.Hide();
    }

    public void DrawItemSlot()
    {
        foreach (Transform child in itemSctionTrm)
        {
            HoldItemSlotContainer container = child.GetComponent<HoldItemSlotContainer>();
            if (container == null)
                continue;

            container.ClearItemSlot();
            container.SetItemSlot(holder.GetHoldObjects(container.Size));
            container.Show();
        }
    }

    public void SetHolder(CharacterHolder holder)
    {
        this.holder = holder;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject target = eventData.pointerCurrentRaycast.gameObject;
        if (target.TryGetComponent<InventoryItemSlot>(out InventoryItemSlot slot))
        {
            ShowItemDescriptor(slot);
        }
    }

    private void ShowItemDescriptor(InventoryItemSlot slot)
    {
        if (slot == null)
            return;

        itemDescriptor.ClearActionButton();
        foreach (HoldItemActionType action in Enum.GetValues(typeof(HoldItemActionType)))
        {
            CreateActionButton(action, slot);
        }
        itemDescriptor.SetItem(slot.Item);
        itemDescriptor.Show();
    }

    private void CreateActionButton(HoldItemActionType type, InventoryItemSlot itemSlot)
    {
        if (itemSlot == null)
            return;

        string text = "";
        Action action = null;

        switch (type)
        {
            case HoldItemActionType.Unhold:
                {
                    if (holder == null)
                        return;

                    IHold holdingObject;
                    if (holder.TryGetHoldingObject((h) =>
                    {
                        Item item = h.Body.GetComponent<Item>();
                        if (item == null)
                            return false;

                        return item.Info == itemSlot.Item.Info;
                    }, out holdingObject) == false)
                        return;

                    IEquipment equipableObject = holdingObject.Body.GetComponent<IEquipment>();
                    if (equipableObject != null)
                    {
                        if(holder.GetEquipmentObject() == equipableObject)
                            return;
                    }

                    text = "Unhold";
                    action = () =>
                    {
                        holder.Unhold(holdingObject);

                        DrawItemSlot();

                        itemDescriptor.Hide();
                    };
                }
                break;
            case HoldItemActionType.Equipment:
                {
                    if (holder == null)
                        return;

                    IHold holdingObject;
                    if (holder.TryGetHoldingObject((h) =>
                    {
                        Item item = h.Body.GetComponent<Item>();
                        if (item == null)
                            return false;

                        return item.Info == itemSlot.Item.Info;
                    }, out holdingObject) == false)
                        return;

                    IEquipment equipableObject = holdingObject.Body.GetComponent<IEquipment>();
                    if (equipableObject == null)
                        return;

                    if (holder.GetEquipmentObject() == equipableObject)
                        return;

                    text = "Equipment";
                    action = () =>
                    {
                        holder.Equipment(equipableObject);

                        ShowItemDescriptor(itemSlot);
                    };
                }
                break;
            case HoldItemActionType.Unequipment:
                {
                    if (holder == null)
                        return;

                    IHold holdingObject;
                    if (holder.TryGetHoldingObject((h) =>
                    {
                        Item item = h.Body.GetComponent<Item>();
                        if (item == null)
                            return false;

                        return item.Info == itemSlot.Item.Info;
                    }, out holdingObject) == false)
                        return;

                    IEquipment equipableObject = holdingObject.Body.GetComponent<IEquipment>();
                    if (equipableObject == null)
                        return;

                    if (holder.GetEquipmentObject() != equipableObject)
                        return;

                    text = "Unequipment";
                    action = () =>
                    {
                        holder.Unequipment();

                        ShowItemDescriptor(itemSlot);
                    };
                }
                break;
        }

        if (text == "" || action == null)
            return;

        itemDescriptor.CreateActionButton(text, action);
    }
}