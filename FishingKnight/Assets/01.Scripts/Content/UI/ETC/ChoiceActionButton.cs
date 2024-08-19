using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChoiceActionButton : ActionButton, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image background;

    [Space]
    [SerializeField] private float fadeTime;

    public override void Initialize()
    {
        base.Initialize();

        background.DOFade(0f, 0f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        background.DOFade(1f, fadeTime);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        background.DOFade(0f, fadeTime);
    }
}
