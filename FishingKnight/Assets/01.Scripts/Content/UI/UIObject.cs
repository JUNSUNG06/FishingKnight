using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObject : MonoBehaviour
{
    private RectTransform rect;
    public RectTransform Rect => rect;

    public virtual void Initialize()
    {
        rect = GetComponent<RectTransform>();
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
