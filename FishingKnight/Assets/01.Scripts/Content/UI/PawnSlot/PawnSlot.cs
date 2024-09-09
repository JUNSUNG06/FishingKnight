using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PawnSlot : UIObject, IPointerClickHandler
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI nameText;

    private PawnSO pawnSO;
    public PawnSO PawnSO => pawnSO;

    public Action<PawnSlot> OnClickEvent;

    public void SetPawnSO(PawnSO pawnSO)
    {
        this.pawnSO = pawnSO;
        image.sprite = pawnSO.Image;
        nameText.text = pawnSO.PawnName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickEvent?.Invoke(this);
    }
}
