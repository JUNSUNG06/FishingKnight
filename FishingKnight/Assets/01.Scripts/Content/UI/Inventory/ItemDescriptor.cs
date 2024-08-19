using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptor : UIObject
{
    private InventoryItem item;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Transform actionButtonParent;
    [SerializeField] private ActionButton actionButtonPrefab;

    public void SetItem(InventoryItem item)
    {
        this.item = item;
        image.sprite = item.Info.ItemImage;
        nameText.text = item.Info.ItemName;
        descriptionText.text = item.Info.Description;
    }

    public void CreateActionButton(string text, Action action)
    {
        ActionButton actionButton = Instantiate(actionButtonPrefab, actionButtonParent);
        actionButton.Initialize();
        actionButton.SetText(text);
        actionButton.SetAction(action);
    }

    public void ClearActionButton()
    {
        actionButtonParent.ClearChild();
    }
}
