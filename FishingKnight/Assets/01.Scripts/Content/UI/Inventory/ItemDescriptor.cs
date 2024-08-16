using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptor : UIObject
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Transform actionButtonParent;
    [SerializeField] private InventoryActionButton actionButtonPrefab;

    public void SetItem(InventoryItem item)
    {
        image.sprite = item.Info.ItemImage;
        nameText.text = item.Info.ItemName;
        descriptionText.text = item.Info.Description;

        ClearActionButton();
    }

    public void CreateActionButton(string text, Action action)
    {
        InventoryActionButton actionButton = Instantiate(actionButtonPrefab, actionButtonParent);
        actionButton.Initialize();
        actionButton.SetText(text);
        actionButton.SetAction(action);
    }

    public void ClearActionButton()
    {
        for(int i = actionButtonParent.childCount - 1; i >= 0; i--)
        {
            Destroy(actionButtonParent.GetChild(i).gameObject);
        }
    }
}
