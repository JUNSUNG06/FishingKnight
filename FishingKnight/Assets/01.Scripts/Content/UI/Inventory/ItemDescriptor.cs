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
    [SerializeField] private GameObject actionButtonPrefab;

    public void SetItem(InventoryItem item)
    {
        image.sprite = item.Info.ItemImage;
        nameText.text = item.Info.ItemName;
        descriptionText.text = item.Info.Description;
    }
}
