using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PawnDescriptor : UIObject
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Transform actionButtonParent;
    [SerializeField] private ActionButton actionButtonPrefab;

    private PawnSO pawnSO;

    public void SetPawn(PawnSO info)
    {
        pawnSO = info;
        image.sprite = info.Image;
        nameText.text = info.PawnName;
        descriptionText.text = info.Description;
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
