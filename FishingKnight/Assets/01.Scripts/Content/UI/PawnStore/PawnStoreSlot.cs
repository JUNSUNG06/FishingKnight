using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PawnStoreSlot : UIObject, IPointerClickHandler
{
    private PawnSO pawnSO; 

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI priceText;

    public event Action<PawnSO> OnClickEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickEvent?.Invoke(pawnSO);
    }

    public void SetPawn(PawnSO info)
    {
        pawnSO = info;
        image.sprite = info.Image;
        nameText.text = info.PawnName;
        descriptionText.text = info.Description;
        priceText.text = info.Price.ToString("N0");
    }
}