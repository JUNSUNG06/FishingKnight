using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemSlot : UIObject, IPointerEnterHandler, IPointerExitHandler
{
    private InventoryItem item;
    public InventoryItem Item => item;

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI countText;

    [Space]
    [SerializeField] private float fadeTime;

    private Image frame;

    public override void Initialize()
    {
        base.Initialize();

        frame = GetComponent<Image>();
        frame.DOFade(0f, 0f);
        countText.text = "0";
    }

    public void SetInventoryItem(InventoryItem item)
    {
        this.item = item;

        icon.sprite = item.Info.Icon;
        countText.text = item.Count > 1 ? item.Count.ToString() : "";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        frame.DOFade(1f, fadeTime);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        frame.DOFade(0f, fadeTime);
    }
}