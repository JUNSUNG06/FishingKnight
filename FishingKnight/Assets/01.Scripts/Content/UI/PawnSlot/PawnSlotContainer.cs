using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnSlotContainer : UIObject
{
    [SerializeField] private float activeTransTime;

    [Space]
    [SerializeField] private Transform buttonArrowImageTrm;

    public override void Show()
    {
        Rect.DOAnchorPosY(0f, activeTransTime);
        buttonArrowImageTrm.transform.DORotate(new Vector3(0f, 0f, -90f), activeTransTime);

        isActive = true;
    }

    public override void Hide()
    {
        Rect.DOAnchorPosY(-Rect.rect.height, activeTransTime);
        buttonArrowImageTrm.transform.DORotate(new Vector3(0f, 0f, 90f), activeTransTime);

        isActive = false;
    }

    public void ToggleActive()
    {
        if(isActive)
        {
            Show();
        }
        else
        {
            Hide();
        }

        isActive = !isActive;
    }
}
