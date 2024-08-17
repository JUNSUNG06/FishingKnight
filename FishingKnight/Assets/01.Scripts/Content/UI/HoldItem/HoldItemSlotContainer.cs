using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoldItemSlotContainer : UIObject
{
    [SerializeField] private SocketType size;
    public SocketType Size => size;

    [Space]
    [SerializeField] private TextMeshProUGUI sizeText;
    [SerializeField] private Transform slotContainerTrm;
    [SerializeField] private InventoryItemSlot slotPrefab;

    public override void Show()
    {
        base.Show();

        sizeText.text = size.ToString();
    }

    public void SetItemSlot(List<IHold> holdObjects)
    {
        foreach (IHold holdObject in holdObjects)
        {
            Item item = holdObject.Body.GetComponent<Item>();
            if (item == null)
                continue;

            InventoryItem inventoryItem = new InventoryItem(item);
            InventoryItemSlot slot = Instantiate(slotPrefab, slotContainerTrm);
            slot.Initialize();
            slot.SetInventoryItem(inventoryItem);
        }
    }

    public void ClearItemSlot()
    {
        for (int i = slotContainerTrm.childCount - 1; i >= 0; i--)
        {
            Destroy(slotContainerTrm.GetChild(i).gameObject);
        }
    }
}